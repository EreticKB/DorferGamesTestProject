using System;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public int StackSize { get; private set; }
    public int _stackSizeActual; //убрать в приват после отладки
    [SerializeField] int _stackLimit;
    MoveToBackpack _collectible;
    [SerializeField] GameObject _backpack;
    Transform _unloadingPlace;
    [SerializeField] GameObject _hayBlock;
    bool _isUnloading;
    float _unloadingTimer;


    private void Update()
    {
        if (!_isUnloading) return;
        _unloadingTimer -= Time.deltaTime;
        if (_unloadingTimer <= 0)
        {
            _unloadingTimer = 0.25f;
            Instantiate(_hayBlock, _unloadingPlace).transform.DOLocalJump(_unloadingPlace.position,0.5f, 1, 1);
        }
    }
    private void OnTriggerEnter(Collider hay)
    {
        if (StackSize >= _stackLimit) return;
        if (hay.TryGetComponent<MoveToBackpack>(out _collectible))
        {
            _collectible.collect(_backpack);
            StackSize++;
        }
    }
    internal void HayHitHome(BackpackController backpackController)
    {
        _stackSizeActual++;
        if (_stackSizeActual % 2 == 0) return;
        backpackController.LoadHay();
    }

    internal void UnloadHay(bool status, Transform barn)
    {
        _isUnloading = status;
        _unloadingPlace = barn;
    }
}
