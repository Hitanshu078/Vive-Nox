using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = .5f;
    public float mouseSensitivity = 2f;
    public float maxVerticalAngle = 80f;
    public float minVerticalAngle = -80f;

    void Update()
    {
        // Handle player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveAmount = moveDirection * movementSpeed * Time.deltaTime;

        transform.Translate(moveAmount);

        // Handle player looking around with the mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotationAmountX = Vector3.up * mouseX * mouseSensitivity;
        Vector3 rotationAmountY = Vector3.left * mouseY * mouseSensitivity;

        transform.Rotate(rotationAmountX);

        Camera camera = GetComponent<Camera>();
        float currentRotationX = camera.transform.eulerAngles.x;

        // Clamp vertical rotation to the specified range
        currentRotationX -= rotationAmountY.y;
        currentRotationX = Mathf.Clamp(currentRotationX, minVerticalAngle, maxVerticalAngle);

        camera.transform.rotation = Quaternion.Euler(currentRotationX, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
    }
}
