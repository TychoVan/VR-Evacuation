using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnter : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject Water;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.GameStart)
            Water.transform.position = new Vector3(Water.transform.position.x, Water.transform.position.y + 0.07f * Time.deltaTime, Water.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager != null)
            if (other.gameObject.CompareTag("Player"))
                gameManager.GameStart = true;

    }
}
