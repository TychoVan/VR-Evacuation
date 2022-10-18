using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralGeneration;


public class GameManager : MonoBehaviour
{
    public static GameManager       Instance { get; private set; }

<<<<<<< Updated upstream:Assets/Code/Tycho/GameManager.cs
=======
    [SerializeField] private Room   StartingRoom;
    public float                    GameDuration        = 300;

    public bool                     GameStart           = false;

>>>>>>> Stashed changes:Assets/Code/GamePlay/GameManager.cs




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

<<<<<<< Updated upstream:Assets/Code/Tycho/GameManager.cs
    [field: SerializeField] public Room StartingRoom { get; private set; }
    
    private void Start()
    {
=======

    private void Start() {
>>>>>>> Stashed changes:Assets/Code/GamePlay/GameManager.cs
        StartGeneratingPath();
    }


    /// <summary>
    /// Open the first door to start a chain of doors opening.
    /// </summary>
    private void StartGeneratingPath() {
        StartingRoom.OpenRandomDoor();
        Debug.Log("Generating path..");
    }
<<<<<<< Updated upstream:Assets/Code/Tycho/GameManager.cs
=======




    private void Update() {
        // Update the gametimer.
        if (GameStart == true) GameTimer();
    }


    /// <summary>
    /// Count down to 0, then activate lose state.
    /// </summary>
    private void GameTimer(){
        GameDuration -= Time.deltaTime;
        if (GameDuration <= 0) SceneManager.LoadScene("Lose");
    }



    private void TempDeath() { 
        SceneManager.LoadScene("Lose"); 
    }
>>>>>>> Stashed changes:Assets/Code/GamePlay/GameManager.cs
}
