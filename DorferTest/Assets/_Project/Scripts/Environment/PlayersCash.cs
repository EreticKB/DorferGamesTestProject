using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCash : MonoBehaviour
{
    public int Cash { get; private set; }
    private void Awake()
    {
        Cash = 0;
    }
    public void SellHay()
    {
        Cash += 15;

    }
}
