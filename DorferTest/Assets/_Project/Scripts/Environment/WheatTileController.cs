using UnityEngine;
using DG.Tweening;

public class WheatTileController : MonoBehaviour
{
    [SerializeField] GameObject _hayBlock;
    [SerializeField] GameObject[] _wheatStalk;
    [SerializeField] Collider _trigger;
    private void OnTriggerEnter(Collider scythe)
    {
        if (scythe.gameObject.tag != "Scythe") return;
        scythe.GetComponent<ScytheController>().ThrowToParent(gameObject);
        DoHarvest();
    }

    private void DoHarvest()
    {
        Vector3 target = new Vector3(Random.Range(-2f, 2f),0.5f, Random.Range(-2f,2f));
        Instantiate(_hayBlock, transform).transform.DOJump(transform.position+target, 2,1,1);
        for (int i = 1; i < _wheatStalk.Length; i++)
        {
            _wheatStalk[i].GetComponent<Renderer>().material.color = Color.black;
            _wheatStalk[i].GetComponent<Renderer>().material.DOColor(new Color32(188, 107,0,255), 10f); 
        }
        _wheatStalk[0].transform.localScale = new Vector3(1.5f, 0.5f, 1.5f);
        _wheatStalk[0].transform.DOScaleY(4f, 10f).OnKill(EnableTrigger);
        _trigger.enabled = false;
    }

    private void EnableTrigger()
    {
        _trigger.enabled = true;
    }
}
