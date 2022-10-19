using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DeathText : MonoBehaviour
{
    private TextMeshProUGUI reasonText;

    private void Start()
    {
        reasonText      = this.gameObject.GetComponent<TextMeshProUGUI>();
        reasonText.text = SceneManagement.Instance.DeathReason;
    }
}
