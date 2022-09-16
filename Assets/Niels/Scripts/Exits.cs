using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exits : MonoBehaviour
{
    public GameObject objects;

    public void ObjectsOn()
    {
        objects.SetActive(true);
    }

    public void ObjectsOff()
    {
        objects.SetActive(false);
    }
}
