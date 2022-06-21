using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    private void Update()
    {
        if (!controller.isGrounded) controller.Move(new Vector3(0, -10 * Time.deltaTime, 0));
    }
}
