using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneration
{
    public class gameRunner : MonoBehaviour
    {
        private List<Room> rooms = new List<Room>();

        private void Start()
        {
            rooms.AddRange(GameObject.FindObjectsOfType<Room>());

            for (int i = 0; i < rooms.Count; i++)
            {
                rooms[i].OpenRandomDoor();
            }
        }
    }
}