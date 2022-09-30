using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BNG
{
    public class Exits : MonoBehaviour
    {
        public GameObject objects;

        public void ObjectsOn()
        {
            objects.SetActive(true);
            Debug.Log("On");
        }

        public void ObjectsOff()
        {
            objects.SetActive(false);
            Debug.Log("On");
        }

        public void DoorSettings(bool state)
        {

            
            GetComponent<DoorHelper>().enabled = false;
        }
    }
}