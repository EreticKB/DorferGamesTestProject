using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class CashInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] PlayersCash _barn;
    bool _check;
    private void Update()
    {
        _text.text = _barn.Cash.ToString();
        if (!_check)
        {
            _check = _barn.Shake;
            if (_barn.Shake)
            {
                transform.DOShakePosition(.9f, 3, 15,10,false,false).OnKill(Release);
            }
        }
    }

    private void Release()
    {
        _check = false;
    }
}
