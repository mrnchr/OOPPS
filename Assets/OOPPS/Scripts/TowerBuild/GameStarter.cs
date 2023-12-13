using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OOPPS.TowerBuild
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] TurtleInstaller installer;

        private void OnEnable()
        {
            foreach (var listener in installer.GetAllIListeners())
            {
                listener.OnEnable();
            }  
        }

        private void OnDisable()
        {
            foreach (var listener in installer.GetAllIListeners())
            {
                listener.OnDisable();
            }
        }

        private void Start()
        { 
            installer.GetObjectLoopControler().InitGameScreen();
            installer.GetObjectLoopControler().StartGame();
           
        }
    }
}