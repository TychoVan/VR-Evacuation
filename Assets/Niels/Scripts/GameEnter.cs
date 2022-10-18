using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if player is nearby and start the game timer.
        if (other.gameObject.CompareTag("Player")) GameManager.Instance.GameStart = true;
    }
}
