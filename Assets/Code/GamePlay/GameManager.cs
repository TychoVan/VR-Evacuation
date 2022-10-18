using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ProceduralGeneration;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float Timer = 300;
    [SerializeField] private Room StartingRoom;


    public bool GameStart = false;

    private void Awake()
    {
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        #endregion
    }

    
    private void Start()
    {
        StartGeneratingPath();
    }


    /// <summary>
    /// Open the first door to start a chain of doors opening.
    /// </summary>
    private void StartGeneratingPath()
    {
        StartingRoom.OpenRandomDoor();
        Debug.Log("Generating path..");
    }


    public void TempDeath()
    {
        SceneManager.LoadScene("Lose");
    }


    private void Update()
    {
        if (GameStart == true)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
                SceneManager.LoadScene("Lose");
        }
    }
}
