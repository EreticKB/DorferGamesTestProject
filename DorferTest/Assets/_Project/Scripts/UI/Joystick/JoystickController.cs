using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool _isFree = true;
    [SerializeField] RectTransform _stick;
    RectTransform _thisRectTransform;
    private Vector3 _stickVelocity = Vector3.zero;
    [SerializeField] private float _stickReturningTime;
    private int _singleTouchCheck; //Проверяет совпадение айди при OnDrag и что стик был отпущен ранее в OnPointerDown.
    private Vector3 _zeroInGlobalCoords;
    private Vector3 _positionDelta;
    [SerializeField] private float _radius;
    private float _radiusScale;
    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;


    private void Awake()
    {
        _singleTouchCheck = -2;
        _thisRectTransform = gameObject.GetComponent<RectTransform>();
        _radiusScale = _thisRectTransform.lossyScale.x;
    }
    void Update()
    {
        _zeroInGlobalCoords = transform.position;
        if (!_isFree) return;
        if (Vector3.Distance(_stick.localPosition, Vector3.zero) < 0.1f) _stick.localPosition = Vector3.zero;
        _stick.localPosition = Vector3.SmoothDamp(_stick.localPosition, Vector3.zero, ref _stickVelocity, _stickReturningTime);
    }
    


    public void OnPointerDown(PointerEventData data)
    {

        if (_singleTouchCheck != -2) return;
        _singleTouchCheck = data.pointerId;
        _isFree = false;
        OnDrag(data);
    }
    public void OnDrag(PointerEventData data)
    {
        if (_singleTouchCheck != data.pointerId) return;
        _positionDelta = Input.mousePosition - _zeroInGlobalCoords;
        if (_positionDelta.sqrMagnitude > Mathf.Pow(_radius * _radiusScale, 2)) _positionDelta = _positionDelta.normalized * _radius * _radiusScale;
        _stick.position = _zeroInGlobalCoords + _positionDelta;
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (_singleTouchCheck != data.pointerId) return;
        _singleTouchCheck = -2;
        _isFree = true;
    }

    public bool GetDelta2Normalized(out Vector2 delta2)
    {
        GetVerticalDeltaNormalized(out float deltaY);
        GetHorizontalDeltaNormalized(out float deltaX);
        delta2 = new Vector2(deltaX, deltaY);
        return _isFree;
    }
    public bool GetVerticalDeltaNormalized(out float delta)
    {
        delta = _positionDelta.y / (_radius * _radiusScale);
        return _isFree;
    }
    public bool GetHorizontalDeltaNormalized(out float delta)
    {
        delta = _positionDelta.x / (_radius * _radiusScale);
        return _isFree;
    }
}
