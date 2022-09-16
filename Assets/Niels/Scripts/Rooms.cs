using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public List<Exits> exits = new List<Exits>();

    void Start()
    {
        for (int i = 0; i < exits.Count; i++)
        {
            exits[i].ObjectsOn();
            exits[Random.Range(0, exits.Count)].ObjectsOff();
        }
    }
}
