using UnityEngine;
using DG.Tweening;

public class MoveToBackpack : MonoBehaviour
{
    internal void collect(GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform);
        transform.DOLocalJump(new Vector3(0, 0, -0.4f), 0.5f, 1, 1).OnKill(ItsDead);
        transform.DORotate(Vector3.zero, 2);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void ItsDead()
    {
        Debug.Log("Killed");
    }

    

}
