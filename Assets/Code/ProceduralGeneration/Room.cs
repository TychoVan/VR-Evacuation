using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneration
{
    public class Room : MonoBehaviour  
    {
        [field: SerializeField] public List<Exits>     Doors;


        /// <summary>
        /// Open 1 of the doors in the room.
        /// </summary>
        public void OpenRandomDoor()
        {
            int i = Random.Range(0, Doors.Count);
            Debug.Log("Opened door" + Doors[i].gameObject.name);
            Doors[i].EnableDoor();
        }
    }
}
