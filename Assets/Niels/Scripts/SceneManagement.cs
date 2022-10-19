using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement           Instance    { get; private set; }
    [field: SerializeField] public string   DeathReason { get; private set; }

        
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
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion

    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Layout");
    }   
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose(string reason)
    {
        DeathReason = reason;
        SceneManager.LoadScene("Lose");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            MainMenu();
    }
}
