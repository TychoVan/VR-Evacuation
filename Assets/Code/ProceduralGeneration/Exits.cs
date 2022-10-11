using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace ProceduralGeneration
{

    public class Exits : MonoBehaviour
    { 
        // Door settings.
        [field: SerializeField] public DoorHelper DoorHelper { get; private set; }
        [field: SerializeField] public Room NextRoom { get; private set; }
    
        // Gameplay settings.
        [Tooltip("Script handling the door settings. Often located in object named Door")]
        [field: SerializeField] public GameObject ExitSign { get; private set; }
        [field: SerializeField] public List<GameObject> BlockingObjects { get; private set; }
    
    
    
    
    
        /// <summary>
        /// Unlocks and initializes the door to be the next door.
        /// </summary>
        public void EnableDoor() {
            DoorHelper.DoorIsLocked = false;
    
            if (ExitSign) ExitSign.SetActive(true);
            if (BlockingObjects != null) {
                foreach (GameObject BlockingObject in BlockingObjects) {
                    BlockingObject.SetActive(true);
                }
            }
    
            //NextRoom.OpenRandomDoor();
        }
    }
}