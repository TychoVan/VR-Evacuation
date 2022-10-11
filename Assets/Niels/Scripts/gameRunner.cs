using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProceduralGeneration
{
    public class gameRunner : MonoBehaviour
    {
        public float timer = 300;

        private List<Room> rooms = new List<Room>();

        private void Start()
        {
            rooms.AddRange(GameObject.FindObjectsOfType<Room>());

            for (int i = 0; i < rooms.Count; i++)
            {
                rooms[i].OpenRandomDoor();
            }
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
                SceneManager.LoadScene("Lose");
        }
    }
}