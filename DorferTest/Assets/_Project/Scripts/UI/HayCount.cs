using TMPro;
using UnityEngine;

public class HayCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] BackpackController _source;
    private void Update()
    {
        _text.text = $"{_source.BackpackAmount}/40";
    }
}
