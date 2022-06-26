using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] CharacterController _character;
    [SerializeField] CharacterRoot root;
    Vector3 _movement;

    private void Update()
    {
        _character.Move(_movement*Time.deltaTime*_speed);
        if (_movement != Vector3.zero)transform.LookAt(transform.position + _movement);
    }
    public void WalkIntoDirection(Vector2 direction)
    {
        direction.Normalize();
        root.CharacterState = CharacterRoot.State.Walking;
        _movement = new Vector3(direction.x, 0, direction.y);
        _animator.SetInteger("Status", 1);
    }

    internal void Stop()
    {
        root.CharacterState = CharacterRoot.State.Idling;
        _animator.SetInteger("Status", 0);
        _movement = Vector3.zero;
    }
}
