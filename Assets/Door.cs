using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Door : MonoBehaviour
{
    public bool                             DoorLocked;
    [SerializeField] private DoorHelper     doorSettings;


    private void inializeDoors()
    {
        //doorSettings.DoorIsLocked = DoorLocked();
    }
}
