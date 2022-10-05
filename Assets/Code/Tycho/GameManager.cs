using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralGeneration;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


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

    [field: SerializeField] public Room StartingRoom { get; private set; }
    
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
}