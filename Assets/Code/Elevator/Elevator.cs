using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Elevator
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] private ElevatorDoor[] doors;

        private bool                            elevatorCalled;
        [SerializeField] private bool           elevatorReady = false;
        private bool                            doorsOpened;

        [Tooltip("Time before the elevator doors open.")]
        [SerializeField] public Vector2         randomWaitTime;
        [SerializeField] public float           waitTime;


        [Tooltip("Time it takes for the doors to open")]
        [SerializeField] public float           openingDuration;

        [Tooltip("Time the doors stay open.")]
        [SerializeField] public float           openTime;

        [Tooltip("Time it takes for the doors to close.")]
        [SerializeField] public float           closingDuration;

        [Header("Player death sequence.")]
        [Tooltip("Event called when te player is insede the elevater while closing.")]
        [SerializeField] private UnityEvent     onPlayerInside;
        private bool playerInside;

        [Header("Audio settings")]
        [SerializeField] private AudioClip      elevatorMoving;
        [SerializeField] private AudioClip      elevatorEndMoving;
        [SerializeField] private AudioClip      doorsMoving;
        [SerializeField] private AudioSource    elevatorDing;
        [SerializeField] private AudioSource    elevatorSounds;




        private void Start() {
            elevatorReady = false;
        }


        #region ElevatorCalling
        /// <summary>
        /// Actions taken when the call button is pushed.
        /// </summary>
        public void OnButtonPushed() {
            if      (!elevatorCalled && !elevatorReady) StartCoroutine(CallElevator());
            else if (!doorsOpened && elevatorReady) StartCoroutine(ElevatorSequence());
        }


        // Wait until the elevator is ready.
        private IEnumerator CallElevator() {
            elevatorCalled = true;

            elevatorSounds.clip = elevatorMoving;
            elevatorSounds.loop = true;
            elevatorSounds.Play();
            
            waitTime       = Random.Range(randomWaitTime.x, randomWaitTime.y);
            
            // Fade in elevator audio.
            float currentTime = 0;
            float start = elevatorSounds.volume;
            while (currentTime < waitTime)
            {
                currentTime += Time.deltaTime;
                elevatorSounds.volume = Mathf.Lerp(0.25f, 1f, currentTime / waitTime);
                yield return null;
            }

            // Play end of elevator moving sound.
            elevatorSounds.Stop();
            elevatorSounds.loop = false;
            elevatorSounds.clip = elevatorEndMoving;
            elevatorSounds.Play();

            // Play elevator arrival sound.
            elevatorDing.Play();

            yield return new WaitForSeconds (elevatorEndMoving.length);


            StartCoroutine(ElevatorSequence());
            elevatorReady  = true;
        }
        #endregion



        #region OpenCloseSequence
        // Play the open and close sequence
        private IEnumerator ElevatorSequence() {
            OpenDoors();

            elevatorSounds.clip = doorsMoving;
            elevatorSounds.Play();

            doorsOpened = true;

            // Fade out elevator doors sound.
            float currentTime = 0;
            while (currentTime < openingDuration)
            {
                currentTime += Time.deltaTime;
                elevatorSounds.volume = Mathf.Lerp(1, 0f, currentTime / openingDuration);
                yield return null;
            }

            elevatorSounds.Stop();
            yield return new WaitForSeconds(openTime);

            CloseDoors();
            elevatorSounds.Play();

            // Fade out elevator doors sound.
            currentTime = 0;
            while (currentTime < openingDuration)
            {
                currentTime += Time.deltaTime;
                elevatorSounds.volume = Mathf.Lerp(1, 0f, currentTime / closingDuration);
                yield return null;
            }

            elevatorSounds.Stop();
            doorsOpened = false;
            if (playerInside) onPlayerInside.Invoke();
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
        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player")) playerInside = false;
        }
        #endregion
    }
}
