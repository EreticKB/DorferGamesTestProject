using UnityEngine;
using UnityEngine.UI;

public class HayCount : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] Collector _source;
    private void Update()
    {
        _text.text = $"{_source.StackSize}";
    }
}