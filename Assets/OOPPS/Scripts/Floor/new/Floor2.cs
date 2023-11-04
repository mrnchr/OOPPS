
using UnityEngine;
namespace OOPPS
{
    public class Floor2 : MonoBehaviour
    {

        private Rigidbody mainRB;
        [SerializeField]
        private Rigidbody childRb;
        [HideInInspector]
        public SpringJoint spJoint;
        private BoxCollider boxCollider;

        private FloorOffsetManager floorOffsetManager;


        [SerializeField]
        private float sideSize;

        private Floor2 prevFloor;
        private Floor2 nextFloor;

        private LevelMover levelMover;

        public bool isHooked { get; set; }
        public bool wasHooked { get; set; }

        private void Awake()
        {
            floorOffsetManager = FindAnyObjectByType<FloorOffsetManager>();
            wasHooked = false;
            isHooked = false;
            levelMover = FindObjectOfType<LevelMover>();
            mainRB = GetComponent<Rigidbody>();

            spJoint = GetComponent<SpringJoint>();
            boxCollider = GetComponent<BoxCollider>();
        }


        private void Start()
        {
            InitSpringJoint();
        }

        protected void InitSpringJoint()
        {
            spJoint.spring = 0f;
            spJoint.damper = 0f;
            spJoint.autoConfigureConnectedAnchor = true;
        }

        public void SetVelocity(Vector3 velocity)
        {
            mainRB.velocity = velocity;
        }

        private void OnTriggerEnter(Collider newFloorCol)
        {
            if (isHooked && newFloorCol.GetComponentInParent<Floor2>())
            {
                if (!newFloorCol.GetComponentInParent<Floor2>().wasHooked)
                {


                    nextFloor = newFloorCol.GetComponentInParent<Floor2>();
                    nextFloor.wasHooked = true;

                    MakeHookWith(nextFloor);

                    //check new floor offset
                    if (Mathf.Abs(spJoint.connectedAnchor.x) > sideSize * 0.75f) //ONLY FOR x AXES!!! change, if would be use another one
                    {
                        //bracke connections
                        spJoint.connectedBody = null;
                        spJoint.spring = 0f;
                        spJoint.damper = 0f;


                        nextFloor.Unhook();
                        nextFloor = null;
                        Debug.Log("не прицепился");
                        //boxCollider.isTrigger = true;
                    }
                    else
                    {

                        Debug.Log("прицепился");
                        // boxCollider.isTrigger = false;
                        if (floorOffsetManager.countOfFloors > 2)
                        {
                            levelMover.Move(newFloorCol.transform.position.y-sideSize);
                        }

                        floorOffsetManager.AddFloor(nextFloor, sideSize * spJoint.connectedAnchor.x);//ONLY FOR x AXES!!! change, if would be use another one
                       // floorOffsetManager.summOffset += sideSize * spJoint.connectedAnchor.x;
                    }
                }
            }

            //get anchor offset by new floor to shake base floor

        }

        /* private void OnTriggerExit(Collider other)
         {
             boxCollider.isTrigger = true;
         }*/


        public void MakeHookWith(Floor2 newFloor)
        {
            Rigidbody newFloorRb = newFloor.GetComponent<Rigidbody>();

            newFloor.prevFloor = this;
            newFloor.isHooked = true; //double work(probably)

            //disable gravity for new floor
            newFloorRb.useGravity = false;
            newFloorRb.velocity = Vector3.zero;

            spJoint.connectedBody = newFloorRb;
            spJoint.spring = 4000f;
            spJoint.damper = 5f;

            boxCollider.enabled = false;
        }

        public void Unhook()
        {
            //levelMover.Move(prevFloor.transform.position.y);
            isHooked = false;
            Destroy(spJoint);
            boxCollider.enabled = false;

            childRb.isKinematic = false;
            childRb.useGravity = true;

            mainRB.freezeRotation = false;
            prevFloor.boxCollider.enabled = true;
            prevFloor = null;


            //Destroy(gameObject, 2f);
            // Invoke("DestroyFloor", 2f);
        }

        private void DestroyFloor()
        {
            Destroy(gameObject, 2f);
        }
    }
}