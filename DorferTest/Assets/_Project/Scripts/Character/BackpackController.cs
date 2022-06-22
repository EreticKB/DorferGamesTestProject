using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackController : MonoBehaviour
{
    [SerializeField] BackpackVisualController _backpack;
    [SerializeField] Collector _collector;
    public void HayHitHome(GameObject hayBlock)
    {
        Destroy(hayBlock);
        _collector.HayHitHome(this);
    }

    public void LoadHay()
    {
        _backpack.Increase();
    }
    public void UnloadHay()
    {
        _backpack.Decrease();
    }
}
