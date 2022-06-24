using System;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public int StackSize { get; private set; }
    [SerializeField] int _stackLimit;
    MoveHay _collectible;
    [SerializeField] GameObject _backpack;
    Transform _unloadingPlace;
    [SerializeField] GameObject _hayBlock;
    [SerializeField]bool _isUnloading;
    float _unloadingTimer;


    private void Update()
    {
        if (!_isUnloading || StackSize <= 0) return;
        _unloadingTimer -= Time.deltaTime;
        if (_unloadingTimer <= 0)
        {
            _unloadingTimer = 0.25f;
            Instantiate(_hayBlock, _backpack.transform.position, new Quaternion(), _backpack.transform).GetComponent<MoveHay>().Unload(_unloadingPlace);
            StackSize--;
            _backpack.GetComponent<BackpackController>().RemoveHayFromBackpack();
        }
    }
    private void OnTriggerEnter(Collider hay)
    {
        if (StackSize >= _stackLimit) return;
        if (hay.TryGetComponent<MoveHay>(out _collectible))
        {
            _collectible.collect(_backpack);
            StackSize++;
        }
    }

    internal void UnloadHay(bool status, Transform barn)
    {
        _isUnloading = status;
        _unloadingPlace = barn;
    }
}
