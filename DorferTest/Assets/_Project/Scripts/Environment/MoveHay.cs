using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MoveHay : MonoBehaviour
{
    bool isAnimationFree = false;

    internal void collect(GameObject parent)
    {
        disablePhysicsAndSetNewParent(parent.transform);
        StartCoroutine(collectAnimation(parent));
    }

    internal void Unload(Transform parent,PlayersCash cash)
    {
        disablePhysicsAndSetNewParent(parent);
        transform.DOLocalJump(new Vector3(0, 0, 0), 2f, 1, 1f).OnComplete(() => InBarn(cash));
    }

    private void disablePhysicsAndSetNewParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    internal void DropOnGround(Vector3 target)
    {
        transform.DOJump(transform.position + target, 2, 1, 1).OnKill(FreeingTween);
    }

    private void FreeingTween()
    {
        isAnimationFree = true;
    }

    private void InBackpack(GameObject parent)
    {
        parent.GetComponent<BackpackController>().PlaceHayIntoBackpack();
        Destroy(gameObject);
    }

    private void InBarn(PlayersCash cash)
    {
        cash.SellHay();
        Destroy(gameObject);
    }
    IEnumerator collectAnimation(GameObject parent)
    {
        yield return new WaitUntil(()=>isAnimationFree);
        transform.DOLocalJump(new Vector3(0, 0, -0.4f), 0.5f, 1, .5f).OnComplete(() => InBackpack(parent));
    }
}
