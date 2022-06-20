using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAndWalk : MonoBehaviour
{
    public Animator lol;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) lol.SetTrigger("StartCut");
        if (Input.GetKeyDown(KeyCode.S)) lol.SetTrigger("StopCut");
    }
}
