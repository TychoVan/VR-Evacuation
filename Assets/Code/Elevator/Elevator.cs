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
        [SerializeField ]private bool               elevatorReady           = false;
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
        [Tooltip("Event called when te player is insede the elevater while closing.")]
        [SerializeField] private UnityEvent         onPlayerInside;
        private bool                                playerInside;

        //[Header("Audio settings")]
        //[SerializeField] private AudioSource        elevatorDing;
        //[SerializeField] private AudioSource        doorsMovingSound;




        private void Start() {
            elevatorReady = false;
        }


#region ElevatorCalling
        /// <summary>
        /// Actions taken when the call button is pushed.
        /// </summary>
        public void OnButtonPushed() {
            if (!elevatorCalled   && !elevatorReady)     StartCoroutine(CallElevator());
            else if (!doorsOpened &&  elevatorReady)     StartCoroutine(ElevatorSequence());
        }


        // Wait until the elevator is ready.
        private IEnumerator CallElevator() {
            elevatorCalled = true;
            waitTime       = Random.Range(randomWaitTime.x, randomWaitTime.y);
            yield return new WaitForSeconds(waitTime);

            //elevatorDing.Play();
            StartCoroutine(ElevatorSequence());
            elevatorReady  = true;
        }
#endregion



#region OpenCloseSequence
        // Play the open and close sequence
        private IEnumerator ElevatorSequence() {
            OpenDoors();
            doorsOpened = true;
            yield return new WaitForSeconds(openingDuration + openTime);
            
            CloseDoors();
            yield return new WaitForSeconds(closingDuration);

            if (playerInside) onPlayerInside.Invoke();
            doorsOpened = false;
        }


        // Start the opening sequence for all doors.
        private void OpenDoors() {
            for (int i = 0; i < doors.Length; i++) StartCoroutine(doors[i].OpenDoor(openingDuration));
        }


        // Start the closing sequence for all doors.
        private void CloseDoors() {
            for (int i = 0; i < doors.Length; i++) StartCoroutine(doors[i].CloseDoor(closingDuration));
        }
#endregion



#region CheckPlayerInside
        // Check when player enters elevator.
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) playerInside = true;
        }

        // Check when player exits elevator.
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) playerInside = false;
        }
#endregion
    }
}
