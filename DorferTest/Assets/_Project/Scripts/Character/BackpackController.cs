using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackController : MonoBehaviour
{
    [SerializeField] BackpackVisualController _backpack;
    [SerializeField] Collector _collector;
    private int _backpackAmount;
    public void PlaceHayIntoBackpack()
    {
        _backpackAmount++;
        if (_backpackAmount % 2 == 0) return;
        _backpack.Increase();
    }
    public void RemoveHayFromBackpack()
    {
        _backpackAmount--;
        if (_backpackAmount % 2 != 0) return;
        _backpack.Decrease();
    }
}
