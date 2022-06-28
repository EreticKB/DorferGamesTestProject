using DG.Tweening;
using System;
using UnityEngine;

public class PlayersCash : MonoBehaviour
{
    [SerializeField] Transform _hay;
    [SerializeField] GameObject _coin;
    [SerializeField] RectTransform _target;
    [SerializeField] int _cash;
    int _cashActualStatus;
    public bool Shake { get; private set; }
    public int Cash { get => _cash; private set => _cash=value ; }

    public void SellHay()
    {
        SetCash(_cashActualStatus+=15);
        GameObject coin = Instantiate(_coin, _target);
        coin.transform.position = Camera.main.WorldToScreenPoint(_hay.position);
        coin.GetComponent<MoveCoin>().Move();
    }
    private void SetCash(int cash)
    {
        _cashActualStatus = cash;
        Shake = true;
        DOTween.To(() => Cash, x => Cash = x, _cashActualStatus, 1).OnKill(StopShake);
    }
    
    private void StopShake()
    {
        Shake = false;
    }
}
