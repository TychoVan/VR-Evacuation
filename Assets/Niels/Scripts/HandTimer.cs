using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandTimer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //TimerText.text = gameManager.Timer.ToString("");
        TimerText.text = "" + gameManager.GameDuration.ToString("f0");
    }
}
