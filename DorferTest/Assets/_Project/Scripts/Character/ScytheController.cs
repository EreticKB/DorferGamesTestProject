using UnityEngine;

public class ScytheController : MonoBehaviour
{
    [SerializeField] CutController parent;

    public void ThrowToParent(GameObject wheat)
    {
        parent.RemoveWheatFromList(wheat);
    }

}
