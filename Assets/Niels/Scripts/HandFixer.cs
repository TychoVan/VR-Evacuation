using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFixer : MonoBehaviour
{
    public Vector3 HandSize;

    void Start()
    {
        HandSize = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        if (new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) != HandSize)
        {
            Debug.Log("reset");
            transform.localScale = new Vector3(HandSize.x, HandSize.y, HandSize.z);
        }
    }
}
