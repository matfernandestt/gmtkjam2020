using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float smoothing = 2f;
    [SerializeField] private float yClampMin = -30f;
    [SerializeField] private float yClampMax = 90f;
    [SerializeField] private GameObject character;
    
    private Vector2 mouseLook;
    private Vector2 smoothV;
    
    private void Awake()
    {
        GameInput.cameraInput += CameraUpdate;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDestroy()
    {
        GameInput.cameraInput -= CameraUpdate;
    }

    private void CameraUpdate(Vector2 input)
    {
        var mouseInputs = new Vector2(input.x, input.y);
        mouseInputs = Vector2.Scale(mouseInputs, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseInputs.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseInputs.y, 1f / smoothing);
        mouseLook += smoothV;

        var look = -mouseLook;
        look.y = Mathf.Clamp(look.y, yClampMin, yClampMax);
        transform.localRotation = Quaternion.AngleAxis(look.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}