using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MoveToBackpack : MonoBehaviour
{
    internal void collect(GameObject parent)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.SetParent(parent.transform);
        transform.DOLocalJump(new Vector3(0, 0, -0.4f), 0.5f, 1, .5f).OnComplete(() => Complete(parent));
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Complete(GameObject parent)
    {
        parent.GetComponent<BackpackController>().HayHitHome(gameObject);
    }

}
