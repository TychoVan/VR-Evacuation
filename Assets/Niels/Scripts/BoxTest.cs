using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class BoxTest : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DoorTest"))
            {
                other.GetComponent<DoorHelper>().DoorIsLocked = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("DoorTest"))
            {
                other.GetComponent<DoorHelper>().DoorIsLocked = false;
            }
        }
    }
}