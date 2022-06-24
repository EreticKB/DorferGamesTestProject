using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MoveHay : MonoBehaviour
{
    internal void collect(GameObject parent)
    {
        disablePhysicsAndSetNewParent(parent.transform);
        transform.DOLocalJump(new Vector3(0, 0, -0.4f), 0.5f, 1, .5f).OnComplete(() => InBackpack(parent));
    }

    internal void Unload(Transform parent)
    {
        disablePhysicsAndSetNewParent(parent);
        transform.DOLocalJump(new Vector3(0, 0, -0.4f), 2f, 1, 1f).OnComplete(() => InBarn(parent.gameObject));
    }

    private void disablePhysicsAndSetNewParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void InBackpack(GameObject parent)
    {
        parent.GetComponent<BackpackController>().PlaceHayIntoBackpack();
        Destroy(gameObject);
    }

    private void InBarn(GameObject parent)
    {
        parent.GetComponent<PlayersCash>().SellHay();
        Destroy(gameObject);
    }
}
