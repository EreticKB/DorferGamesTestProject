using UnityEngine;

public class Collector : MonoBehaviour
{
    public int StackSize { get; private set; }
    [SerializeField] int _stackLimit;
    MoveToBackpack _collectible;
    [SerializeField] GameObject _backpack;
    private void OnTriggerEnter(Collider hay)
    {
        if (StackSize >= _stackLimit) return;
        if (hay.TryGetComponent<MoveToBackpack>(out _collectible))
        {
            _collectible.collect(_backpack);
            StackSize++;
        }
    }
}
