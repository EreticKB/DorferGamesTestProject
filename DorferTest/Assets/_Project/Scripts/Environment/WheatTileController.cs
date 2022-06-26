using UnityEngine;
using DG.Tweening;

public class WheatTileController : MonoBehaviour
{
    [SerializeField] GameObject _hayBlock;
    [SerializeField] GameObject[] _wheatStalk;
    [SerializeField] Collider _cuttingTrigger;
    [SerializeField] bool _alreadyInList;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Scythe") return;
        collider.GetComponent<ScytheController>().ThrowToParent(gameObject);
        DoHarvest();
    }

    private void DoHarvest()
    {
        Vector3 target = new Vector3(Random.Range(-2f, 2f),0.5f, Random.Range(-2f,2f));
        Instantiate(_hayBlock, transform).GetComponent<MoveHay>().DropOnGround(target);//transform.DOJump(transform.position+target, 2,1,1);
        for (int i = 1; i < _wheatStalk.Length; i++)
        {
            _wheatStalk[i].GetComponent<Renderer>().material.color = Color.black;
            _wheatStalk[i].GetComponent<Renderer>().material.DOColor(new Color32(188, 107,0,255), 10f); 
        }
        _wheatStalk[0].transform.localScale = new Vector3(1.5f, 0.5f, 1.5f);
        _wheatStalk[0].transform.DOScaleY(4f, 10f).OnKill(EnableCuttingTrigger);
        _cuttingTrigger.enabled = false;
    }
    private void EnableCuttingTrigger()
    {
        _cuttingTrigger.enabled = true;
        _alreadyInList = false;
    }
    private void OnTriggerStay(Collider player)
    {
        if (_alreadyInList) return;
        if (player.tag != "Player") return;
        player.GetComponent<CutController>().AddIntoList(gameObject);
        _alreadyInList = true;
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.tag != "Player") return;
        player.GetComponent<CutController>().RemoveFromList(gameObject);
        _alreadyInList = false;
    }

}
