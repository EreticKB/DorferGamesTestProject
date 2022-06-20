using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private float _speed;
    [SerializeField] CharacterController character;
    Vector3 _movement;

    private void Update()
    {
        character.Move(_movement*_speed);
        if (_movement != Vector3.zero)transform.LookAt(transform.position + _movement);
    }
    public void WalkIntoDirection(Vector2 direction)
    {
        direction.Normalize();
        _movement = new Vector3(direction.x, 0, direction.y);
        animator.SetInteger("Status", 1);

        Debug.Log(_movement);
    }

    internal void Stop()
    {
        animator.SetInteger("Status", 0);
        _movement = Vector3.zero;
    }
}
