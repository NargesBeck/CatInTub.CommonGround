using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private float XRotation = 0f;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Transform PlayerParent;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * PlayerSettings.Instance.MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * PlayerSettings.Instance.MouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f); // Prevent over-rotation

        PlayerCamera.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        PlayerParent.Rotate(Vector3.up * mouseX);
    }
}
