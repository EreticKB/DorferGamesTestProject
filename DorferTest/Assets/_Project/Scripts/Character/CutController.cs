using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _scythe;
    List<GameObject> _ripeWheat = new List<GameObject>();
    [SerializeField]bool _isSearch;
    Vector3 _nearest;
    private void Update()
    {
        if (!_isSearch) return;
        _nearest = Vector3.zero;
        _isSearch = false;
        if (_ripeWheat.Count != 0) SearchNearest();
        if (_nearest != Vector3.zero) CutTheWheat();
    }

    private void SearchNearest()
    {
        if (_ripeWheat.Count < 2) _nearest = _ripeWheat[0].transform.position;
        else
        {
            _nearest = _ripeWheat[0].transform.position;
            foreach (GameObject tile in _ripeWheat)
            {
                if (Vector3.SqrMagnitude(tile.transform.position - transform.position) < Vector3.SqrMagnitude(_nearest - transform.position)) _nearest = tile.transform.position;
            }
        }
    }

    private void CutTheWheat()
    {
        transform.LookAt(new Vector3(_nearest.x, 0, _nearest.z));
        _animator.SetInteger("Status", 2);
        StartCoroutine(ControlScythe());
        Debug.Log("StarCut");
    }

    public void HideScythe()
    {
        _scythe.SetActive(false);
    }

    private void OnTriggerEnter(Collider ripeWheat)
    {
        if (ripeWheat.gameObject.tag != "Wheat") return;
        _ripeWheat.Add(ripeWheat.gameObject);
    }

    private void OnTriggerExit(Collider ripeWheat)
    {
        if (ripeWheat.gameObject.tag != "Wheat") return;
        RemoveWheatFromList(ripeWheat.gameObject);
    }

    public void RemoveWheatFromList(GameObject wheat)
    {
        _ripeWheat.Remove(wheat);
    }

    public void SearchMode()
    {
        _isSearch = true;
    }

    IEnumerator ControlScythe()
    {
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f);
        _scythe.SetActive(true);
        _animator.SetInteger("Status", 0);
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f);
        HideScythe();
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .99f);
        SearchMode();
    }
}
