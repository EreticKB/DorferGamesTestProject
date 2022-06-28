using UnityEngine;
using DG.Tweening;

public class MoveCoin : MonoBehaviour
{
    internal void Move()
    {
        transform.DOLocalMove(Vector3.zero, 1).OnKill(KillCoin);
    }

    private void KillCoin()
    {
        Destroy(gameObject);
    }
}
