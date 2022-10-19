using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reasonText;

    private void Start()
    {
        reasonText.text = SceneManagement.Instance.DeathReason;
    }


    public void Replay()
    {
        SceneManagement.Instance.PlayGame();
    }


    public void Quit()
    {
        SceneManagement.Instance.MainMenu();
    }
}
