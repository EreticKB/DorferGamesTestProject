using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unloader : MonoBehaviour
{
    [SerializeField] Transform _hay;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        other.GetComponent<Collector>().UnloadHay(true, _hay);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        other.GetComponent<Collector>().UnloadHay();
    }
}
