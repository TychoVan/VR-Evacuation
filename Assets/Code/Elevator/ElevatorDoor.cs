using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Elevator
{
    public class ElevatorDoor : MonoBehaviour
    {
        [SerializeField] private AnimationCurve OpenAnimation;
        [SerializeField] private AnimationCurve CloseAnimation;

        [SerializeField] private Vector3        openPosition;
        private Vector3                         startPositon;




        private void Start()
        {
            startPositon = transform.position;
        }


        /// <summary>
        /// Moves this door object from an open to a closed position. 
        /// </summary>
        /// <param name="openingTime">Time it takes for the door to move from state A to B.</param>
        public IEnumerator OpenDoor(float openingTime) {
            float timer = 0.0f;
            while (timer <= openingTime) {
                transform.position = Vector3.Lerp(startPositon, startPositon + openPosition, OpenAnimation.Evaluate(timer / openingTime));
                timer += Time.deltaTime;
                yield return null;
            }
        }


        /// <summary>
        /// Moves this door object from a closed to an open position. 
        /// </summary>
        /// <param name="closingTime">Time it takes for the door to move from state A to B.</param>
        public IEnumerator CloseDoor(float closingTime) {
            float timer = 0.0f;
            while (timer <= closingTime) {
                transform.position = Vector3.Lerp(startPositon + openPosition, startPositon, OpenAnimation.Evaluate(timer / closingTime));
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
