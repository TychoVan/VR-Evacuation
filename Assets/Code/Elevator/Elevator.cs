using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Elevator
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] private ElevatorDoor[]     doors;

        private bool                                elevatorCalled;
        [SerializeField ]private bool               elevatorReady;
        private bool                                doorsOpened;

        [Tooltip("Time before the elevator doors open.")]
        [SerializeField] public Vector2             randomWaitTime;
        [SerializeField] public float               waitTime;


        [Tooltip("Time it takes for the doors to open")]
        [SerializeField] public float               openingDuration;

        [Tooltip("Time the doors stay open.")]
        [SerializeField] public float               openTime;

        [Tooltip("Time it takes for the doors to close.")]
        [SerializeField] public float               closingDuration;

        [Header("Player death sequence.")]
        [SerializeField] private UnityEvent         onPlayerInside;
        private bool                                playerInside;




        private void Start() {
            elevatorReady = false;
        }


        public void CallElevator() {
            if (!elevatorCalled   && !elevatorReady)     StartCoroutine(WaitForElevator());
            else if (!doorsOpened &&  elevatorReady)     StartCoroutine(ElevatorSequence());
        }


        private IEnumerator WaitForElevator() {
            elevatorCalled = true;
            waitTime = Random.Range(randomWaitTime.x, randomWaitTime.y);
            yield return new WaitForSeconds(waitTime);
            
            StartCoroutine(ElevatorSequence());
            elevatorReady = true;
        }


        #region OpenCloseSequence
        private IEnumerator ElevatorSequence() {
            OpenDoors();
            doorsOpened = true;
            yield return new WaitForSeconds(openingDuration + openTime);
            
            CloseDoors();
            yield return new WaitForSeconds(closingDuration);

            if (playerInside) onPlayerInside.Invoke();
            doorsOpened = false;
        }


        private void OpenDoors() {
            for (int i = 0; i < doors.Length; i++) StartCoroutine(doors[i].OpenDoor(openingDuration));
        }


        private void CloseDoors() {
            for (int i = 0; i < doors.Length; i++) StartCoroutine(doors[i].CloseDoor(closingDuration));
        }
        #endregion



        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) playerInside = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) playerInside = false;
        }
    }
}
