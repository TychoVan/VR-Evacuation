using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private SceneManagement SceneManager;
    private float timer = 10;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            GetComponent<SceneManagement>().MainMenu();
    }
}
