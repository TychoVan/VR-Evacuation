using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.SceneManagement;
using ProceduralGeneration;


public class GameManager : MonoBehaviour
{
    public static GameManager       Instance { get; private set; }

    [SerializeField] private Room   StartingRoom;
    public float                    GameDuration        = 300;

    public bool                     GameStart           = false;
    public UnityEvent               OnTimeUp;




    private void Awake() {
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

    
    private void Start() {
        // Start path generation.
        StartGeneratingPath();
    }


    /// <summary>
    /// Open the first door to start a chain of doors opening.
    /// </summary>
    private void StartGeneratingPath() {
        StartingRoom.OpenRandomDoor();
    }


    private void Update()  {
        if (GameStart) GameTimer();
    }


    /// <summary>
    /// Count down game duration then invoke game end.
    /// </summary>
    private void GameTimer()
    {
            GameDuration -= Time.deltaTime;
            if (GameDuration <= 0) OnTimeUp.Invoke();
    }




    // Temporary
    public void TempDeath() {
        SceneManager.LoadScene("Lose");
    }
}
