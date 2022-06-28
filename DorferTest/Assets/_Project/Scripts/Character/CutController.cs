using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CutController : MonoBehaviour
{
    [SerializeField] CharacterRoot root;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _scythe;
    [SerializeField] List<GameObject> _ripeWheat = new List<GameObject>();
    Vector3 _nearest;
    [Header("Times for scythe enabling")]
    [SerializeField] float _enableTime = 0.35f;
    [SerializeField] float _disableTime = 0.5f;
    float _clearTimer;
    private void Update()
    {
        if (root.CharacterState == CharacterRoot.State.Walking)
        {
            _scythe.SetActive(false);

            StopAllCoroutines();
        }
        if (root.CharacterState != CharacterRoot.State.Idling) return;
        _nearest = Vector3.zero;
        if (_ripeWheat.Count != 0) SearchNearest();
        if (_nearest != Vector3.zero) CutTheWheat();
    }
    private void SearchNearest()
    {
        _nearest = _ripeWheat[0].transform.position;
        if (_ripeWheat.Count < 2) return;
        for (int i = 1; i < _ripeWheat.Count; i++)
        {
            if (Vector3.SqrMagnitude(_ripeWheat[i].transform.position - transform.position) <
                    Vector3.SqrMagnitude(_nearest - transform.position))
                _nearest = _ripeWheat[i].transform.position;
        }

    }

    private void CutTheWheat()
    {
        root.CharacterState = CharacterRoot.State.Cutting;
        transform.DOLookAt(_nearest, 0.1f, AxisConstraint.Y);
        _animator.SetInteger("Status", 2);
        StartCoroutine(ControlScythe());
    }
    internal void AddIntoList(GameObject ripeWheat)
    {
        if (_ripeWheat.Contains(ripeWheat)) return;
        _ripeWheat.Add(ripeWheat);
    }

    internal void RemoveFromList(GameObject ripeWheat)
    {
        _ripeWheat.Remove(ripeWheat);
    }

    IEnumerator ControlScythe()
    {
        yield return new WaitForSeconds(_enableTime);
        _scythe.SetActive(true);
        _animator.SetInteger("Status", 0);
        yield return new WaitForSeconds(_disableTime);
        _scythe.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        root.CharacterState = CharacterRoot.State.Idling;
    }
}
