// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 10:33:11
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：指引箭头
// 作 者：SW
// 创建时间：2019/01/18 11:14:09
// 版 本：v 1.0
// ========================================================
using UnityEngine;

/// <summary>
/// 行军路线
/// </summary>
public class MapLine : MonoBehaviour
{
    public GameObject StartGameObject;
    public GameObject EndGameObject;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _rotation = Vector3.zero;

    private Material _material;
    private bool _isMove;
    private Vector2 _moveDir;
    private Vector2 _resetOffset;

    void Awake()
    {
        _isMove = false;
        _moveDir = new Vector2(0, 0.01f);
        _resetOffset = new Vector2(0, 100);
        _material = GetComponent<Renderer>().material;
        _startPos = StartGameObject.transform.position;
        _endPos = EndGameObject.transform.position;


        SetLine(_startPos, _endPos);
    }

    /// <summary>
    /// 设置材质的Offset的属性，让箭头移动起来
    /// </summary>
    private void Update()
    {
        if (_isMove)
        {
            if (_material.mainTextureOffset == _resetOffset)
                _material.mainTextureOffset = _moveDir;
            _material.mainTextureOffset += _moveDir;
        }
    }

    public void SetLine(Vector3 startPos, Vector3 endPos)
    {
        this._startPos = startPos;
        this._endPos = endPos;
        transform.localScale = Vector3.one * 0.5f;
        transform.position = startPos;
        transform.eulerAngles = Vector3.zero;

        var scale = transform.localScale;
        var lineLong = CalLineLong() * 0.2f;
        scale.z = scale.z * lineLong;
        transform.localScale = scale;
        _rotation.y = CalLineAngle();
        transform.eulerAngles = _rotation;
        _material.mainTextureScale = new Vector2(1, lineLong);
        transform.Translate(0, 0, lineLong / 4, Space.Self);
        _isMove = true;
    }

    /// <summary>
    /// 计算行军路线长度
    /// </summary>
    private float CalLineLong()
    {
        return Mathf.Sqrt(Mathf.Pow(_startPos.x - _endPos.x, 2) + Mathf.Pow(_startPos.z - _endPos.z, 2));
    }

    /// <summary>
    /// 计算行军路线角度
    /// </summary>
    private float CalLineAngle()
    {
        //斜边长度
        float length = Mathf.Sqrt(Mathf.Pow((_startPos.x - _endPos.x), 2) + Mathf.Pow((_startPos.z - _endPos.z), 2));
        //对边比斜边 sin
        float hudu = Mathf.Asin(Mathf.Abs(_startPos.z - _endPos.z) / length);
        float ag = hudu * 180 / Mathf.PI;

        //第一象限
        if ((_endPos.x - _startPos.x) >= 0 && (_endPos.z - _startPos.z >= 0))
            ag = -ag + 90;
        //第二象限
        else if ((_endPos.x - _startPos.x) <= 0 && (_endPos.z - _startPos.z >= 0))
            ag = ag - 90;
        //第三象限
        else if ((_endPos.x - _startPos.x) <= 0 && (_endPos.z - _startPos.z) <= 0)
            ag = -ag + 270;
        //第四象限
        else if ((_endPos.x - _startPos.x) >= 0 && (_endPos.z - _startPos.z) <= 0)
            ag = ag + 90;
        return ag;
    }
}