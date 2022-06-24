using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideableJoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] GameObject JoyStickBase;
    [SerializeField] GameObject JoyStickStick;
    [SerializeField][Range(0.2f, 3f)] float _joyScale;
    [SerializeField] GameObject Character;  
    private int _singleTouchCheck;
    private Vector3 _zeroInGlobalCoords;
    private float _radiusScale;

    private void Awake()
    {
        _singleTouchCheck = -2;
        _radiusScale = transform.lossyScale.x;
        JoyStickBase.GetComponent<RectTransform>().sizeDelta = new Vector2(200f * _joyScale, 200f * _joyScale);
        JoyStickStick.GetComponent<RectTransform>().sizeDelta = new Vector2(50f * _joyScale, 50f * _joyScale);
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (_singleTouchCheck != -2) return;
        JoyStickBase.SetActive(true);
        JoyStickStick.SetActive(true);
        JoyStickBase.transform.position = Input.mousePosition;
        _zeroInGlobalCoords = JoyStickBase.transform.position;
        _singleTouchCheck = data.pointerId;
        OnDrag(data);
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (_singleTouchCheck != data.pointerId) return;
        _singleTouchCheck = -2;
        JoyStickBase.SetActive(false);
        JoyStickStick.SetActive(false);
        Character.GetComponent<Walking>().Stop();
    }

    public void OnDrag(PointerEventData data)
    {
        if (_singleTouchCheck != data.pointerId) return;
        Vector3 positionDelta = Input.mousePosition - _zeroInGlobalCoords;
        if (positionDelta.sqrMagnitude > Mathf.Pow(100f * _joyScale * _radiusScale, 2)) positionDelta = positionDelta.normalized * 100f * _joyScale * _radiusScale;
        JoyStickStick.transform.position = _zeroInGlobalCoords + positionDelta;
        Character.GetComponent<Walking>().WalkIntoDirection(positionDelta);
    }


}
