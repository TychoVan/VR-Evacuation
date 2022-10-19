using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class FloatieManager : MonoBehaviour
    {
        private List<Grabbable> floaties = new List<Grabbable>();

        void Start()
        {
            floaties.AddRange(FindObjectsOfType<Grabbable>());

            for (int i = 0; i < floaties.Count; i++)
            {
                floaties[i].gameObject.AddComponent<Floaties>();
            }
        }
    }
}