using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floaties : MonoBehaviour
{
    public GameObject Water;

    private bool InWater = false;

    void Start()
    {
        Water = GameObject.Find("Ocean");
    }

    private void Update()
    {
        if (InWater)
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, Water.transform.position.y, transform.position.z), 1 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ocean")
        {
            InWater = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
