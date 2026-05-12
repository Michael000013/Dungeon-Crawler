using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
{
    if (mainCamera == null) return;

    // This keeps the sprite facing the camera but perfectly vertical
    Vector3 targetPosition = transform.position + mainCamera.transform.rotation * Vector3.forward;
    Vector3 targetOrientation = mainCamera.transform.rotation * Vector3.up;
    transform.LookAt(targetPosition, targetOrientation);
}
}