using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BNG
{
    public class Pause : MonoBehaviour
    {
        [Tooltip("Input Action used to initiate slow time")]
        public InputActionReference SlowTimeAction;

        public GameObject pauseMenu;

        // Update is called once per frame
        void Update()
        {
            if (InputBridge.Instance.YButton)
            {
                if (isActiveAndEnabled)
                {

                }
                pauseMenu.SetActive(true);
            }
        }
    }
}