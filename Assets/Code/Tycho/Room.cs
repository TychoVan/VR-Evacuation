using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

[System.Serializable]
public class Room : MonoBehaviour   
{
    [field: SerializeField] public GameObject           RoomObject;
    [field: SerializeField] public List<Door>     Doors;
}
