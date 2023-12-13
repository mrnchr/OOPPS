using UnityEngine;

namespace OOPPS.City
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Material _sharedMaterial;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Texture2D _texture;
        [SerializeField] private Material _material;

        public void Awake()
        {
            _renderer.material.mainTexture = _texture;
        }

        public void RecreateMaterial()
        {
            _material = new Material(_sharedMaterial);
            _renderer.material = _material;
            _material.mainTexture = _texture;
        }

        private void OnValidate()
        {
            if (_texture)
            {
                RecreateMaterial();
                _material.mainTexture = _texture;
            }
        }
    }
}