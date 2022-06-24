using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] CharacterController _character;
    Vector3 _movement;

    private void Update()
    {
        _character.Move(_movement*Time.deltaTime*_speed);
        if (_movement != Vector3.zero)transform.LookAt(transform.position + _movement);
    }
    public void WalkIntoDirection(Vector2 direction)
    {
        direction.Normalize();
        _movement = new Vector3(direction.x, 0, direction.y);
        _animator.SetInteger("Status", 1);
        gameObject.GetComponent<CutController>().HideScythe();
    }

    internal void Stop()
    {
        _animator.SetInteger("Status", 0);
        Debug.Log("Stop");
        _movement = Vector3.zero;
        gameObject.GetComponent<CutController>().SearchMode();
    }
}
