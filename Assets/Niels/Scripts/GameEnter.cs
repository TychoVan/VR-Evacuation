using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnter : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager != null)
            if (other.gameObject.CompareTag("Player"))
                gameManager.GameStart = true;
    }
}
