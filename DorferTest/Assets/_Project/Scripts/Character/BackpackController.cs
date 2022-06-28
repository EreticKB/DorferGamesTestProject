using UnityEngine;

public class BackpackController : MonoBehaviour
{
    [SerializeField] BackpackVisualController _backpack;
    [SerializeField] Collector _collector;
    public int BackpackAmount { get; private set; }
    public void PlaceHayIntoBackpack()
    {
        BackpackAmount++;
        if (BackpackAmount % 2 == 0) return;
        _backpack.Increase();
    }
    public void RemoveHayFromBackpack()
    {
        BackpackAmount--;
        if (BackpackAmount % 2 != 0) return;
        _backpack.Decrease();
    }
}
