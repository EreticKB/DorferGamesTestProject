using UnityEngine;
using UnityEngine.UI;

public class CashInfo : MonoBehaviour
{
    [SerializeField] PlayersCash _barn;
    [SerializeField] Text _text;
    private void Update()
    {
        _text.text = _barn.Cash.ToString();
    }
}
