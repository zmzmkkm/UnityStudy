// ========================================================
// 描 述：模仿旋转物体的相机的移动与旋转
// 作 者：SW
// 创建时间：2017/12/08 16:12:19
// 版 本：v 1.0
// ========================================================
using UnityEngine;
/// <summary>
/// 鼠标移到旋转缩放方法类
/// </summary>
public class FxMouse : MonoBehaviour
{
    public Transform m_TargetTrans;
    public Camera m_GrayscaleCamara;
    public Shader m_GrayscaleShader;

    public bool m_bRaycastHit;
    protected const float m_fDefaultDistance = 8.0f;
    protected const float m_fDefaultWheelSpeed = 5.0f;
    public float m_fDistance = m_fDefaultDistance;
    public float m_fXSpeed = 150.0f;
    public float m_fYSpeed = 100.0f;
    public float m_fWheelSpeed = m_fDefaultWheelSpeed;

    public float m_fYMinLimit = -90f;
    public float m_fYMaxLimit = 90f;

    public float m_fDistanceMin = 1.0f;
    public float m_fDistanceMax = 10000;

    public int m_nMoveInputIndex = 1;
    public int m_nRotInputIndex = 0;

    public float m_fXRot = 0.0f;
    public float m_fYRot = 0.0f;

    // HandControl
    protected bool m_bHandEnable = true;
    protected Vector3 m_MovePostion;
    protected Vector3 m_OldMousePos;
    protected bool m_bLeftClick;
    protected bool m_bRightClick;

    private bool isTuodong = false;
    /// <summary>
    /// 上一帧鼠标所在的位置
    /// </summary>
    private Vector3 oldMousePosition = Vector3.zero;
    /// <summary>
    /// 当前帧鼠标所在的位置
    /// </summary>
    private Vector3 newMousePosition = Vector3.zero;
    public bool Ismove = true;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="angle"></param>
    public void ChangeAngle(float angle)
    {
        m_fYRot = angle;
        m_fXRot = 0;
        m_MovePostion = Vector3.zero;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bEnable"></param>
    public void SetHandControl(bool bEnable)
    {
        m_bHandEnable = bEnable;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fDistance"></param>
    public void SetDistance(float fDistance)
    {
        m_fDistance = fDistance;
        PlayerPrefs.SetFloat("FxmTestMouse.m_fDistance", m_fDistance);
        UpdateCamera(true);
    }

    // -----------------------------------------------------------------
    //void OnEnable()
    //{
    //    m_fDistance	= PlayerPrefs.GetFloat("FxmTestMouse.m_fDistance", m_fDistance);
    //}

    void Start()
    {
        if (Camera.main == null)
            return;
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update()
    {
        if (!Ismove)
        {
            return;
        }

        UpdateCamera(false);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bOnlyZoom"></param>
    public void UpdateCamera(bool bOnlyZoom)
    {
        if (Camera.main == null)
            return;

        if (m_fWheelSpeed < 0)
            m_fWheelSpeed = m_fDefaultWheelSpeed;

        float fDistRate = m_fDistance / m_fDefaultDistance;
        if (Mathf.Abs(fDistRate) < 1)
        {
            fDistRate = 1;
        }
        else
        {
            fDistRate = Mathf.Abs(fDistRate);
        }
        float fOldDistance = m_fDistance;

        if (m_TargetTrans)
        {
            m_fDistance = Mathf.Clamp(m_fDistance - Input.GetAxis("Mouse ScrollWheel") * m_fWheelSpeed * fDistRate, m_fDistanceMin, m_fDistanceMax);

            // 
            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize = m_fDistance * 0.60f;
                if (m_GrayscaleCamara != null)
                    m_GrayscaleCamara.orthographicSize = m_fDistance * 0.60f;
            }

            if (!bOnlyZoom && m_bRightClick && Input.GetMouseButton(m_nRotInputIndex))
            {
                newMousePosition = Input.mousePosition;
                if (!isTuodong)
                {
                    oldMousePosition = newMousePosition;
                    isTuodong = true;
                }
                else
                {
                    m_fXRot += (newMousePosition.x - oldMousePosition.x) * m_fXSpeed * 0.02f;// * m_fDistance * 0.02f;
                    m_fYRot -= (newMousePosition.y - oldMousePosition.y) * m_fYSpeed * 0.02f;
                    oldMousePosition = newMousePosition;
                }
            }

            if (!bOnlyZoom && Input.GetMouseButtonDown(m_nRotInputIndex))
                m_bRightClick = true;
            if (!bOnlyZoom && Input.GetMouseButtonUp(m_nRotInputIndex))
                m_bRightClick = false;

            m_fYRot = ClampAngle(m_fYRot, m_fYMinLimit, m_fYMaxLimit);

            Quaternion rotation = Quaternion.Euler(m_fYRot, m_fXRot, 0);

            if (m_bRaycastHit)
            {
                RaycastHit hit;
                if (Physics.Linecast(m_TargetTrans.position, Camera.main.transform.position, out hit))
                {
                    m_fDistance -= hit.distance;
                }
            }

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -m_fDistance);
            Vector3 position = rotation * negDistance + m_TargetTrans.position;

            Camera.main.transform.rotation = rotation;
            Camera.main.transform.position = position;
            UpdatePosition(Camera.main.transform);
            if (m_GrayscaleCamara != null)
            {
                m_GrayscaleCamara.transform.rotation = Camera.main.transform.rotation;
                m_GrayscaleCamara.transform.position = Camera.main.transform.position;
            }

            // save
            if (fOldDistance != m_fDistance)
                PlayerPrefs.SetFloat("FxmTestMouse.m_fDistance", m_fDistance);

            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(2))
            {
                isTuodong = false;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="camera"></param>
    void UpdatePosition(Transform camera)
    {
        if (m_bHandEnable)
        {
            if (Input.GetMouseButtonDown(m_nMoveInputIndex))
            {
                m_OldMousePos = Input.mousePosition;
                m_bLeftClick = true;
            }

            if (m_bLeftClick && Input.GetMouseButton(m_nMoveInputIndex))
            {
                Vector3 currMousePos = Input.mousePosition;
                float worldlen = GetWorldPerScreenPixel(m_TargetTrans.transform.position);

                m_MovePostion += (m_OldMousePos - currMousePos) * worldlen;
                m_OldMousePos = currMousePos;
            }
            if (Input.GetMouseButtonUp(m_nMoveInputIndex))
                m_bLeftClick = false;
        }

        camera.Translate(m_MovePostion, Space.Self);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="worldPoint"></param>
    /// <returns></returns>
    public static float GetWorldPerScreenPixel(Vector3 worldPoint)
    {
        Camera cam = Camera.main;
        if (cam == null)
            return 0;
        Plane nearPlane = new Plane(cam.transform.forward, cam.transform.position);
        float dist = nearPlane.GetDistanceToPoint(worldPoint);
        float sample = 100;
        return Vector3.Distance(cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 - sample / 2, dist)), cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 + sample / 2, dist))) / sample;
    }

    public void testBtn()
    {
        Camera.main.transform.GetComponent<FxMouse>().m_fXRot = 200;
        Camera.main.transform.GetComponent<FxMouse>().m_fYRot = 90;
        Camera.main.transform.GetComponent<FxMouse>().m_fDistance = 20;
        UpdateCamera(false);
    }
}