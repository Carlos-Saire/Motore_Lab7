using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControler : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachinePOV povComponent;
    private float xCamera;
    private float yCamera;
    private float CurrentY;
    [SerializeField] private float verticalSpeed; 
    [SerializeField] private float horizontalSpeed;
    [SerializeField]private float verticalMin;
    [SerializeField]private float verticalMax;
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        povComponent = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }
    void Update()
    {
        CurrentY = povComponent.m_VerticalAxis.Value + yCamera * verticalSpeed * Time.deltaTime;
        povComponent.m_VerticalAxis.Value = Mathf.Clamp(CurrentY, verticalMin, verticalMax);
        povComponent.m_HorizontalAxis.Value = povComponent.m_HorizontalAxis.Value + xCamera * horizontalSpeed * Time.deltaTime;
    }
    public void XCamera(InputAction.CallbackContext context)
    {
        xCamera=context.ReadValue<float>();
    }
    public void YCamera(InputAction.CallbackContext context)
    {
        yCamera = -context.ReadValue<float>();
    }
}
