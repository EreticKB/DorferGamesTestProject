using System;
using UnityEngine;
public class BackpackVisualController : MonoBehaviour
{
    [SerializeField] GameObject[] _hayBlocks;
    int _pointer;

    private void Awake()
    {
        _pointer = -1;
    }

    public void Increase()
    {
        if (_pointer >= 20) throw new ArgumentOutOfRangeException("You can't increase further.");
        _pointer++;
        _hayBlocks[_pointer].SetActive(true);
    }

    public void Decrease()
    {
        if (_pointer < 0) throw new ArgumentOutOfRangeException("You can't decrease further.");
        _hayBlocks[_pointer].SetActive(false);
        _pointer--;
    }
}
