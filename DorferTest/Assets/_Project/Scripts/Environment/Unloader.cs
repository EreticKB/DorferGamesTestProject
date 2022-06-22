using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unloader : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Collector>().UnloadHay(true, transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Collector>().UnloadHay(false, transform);
    }
}
