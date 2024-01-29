using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 targetOffset; // Target offset to gradually reach
    public float rotationSpeed = 2.0f; // Speed of rotation

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Gradually adjust the offset
            Vector3 offset = Vector3.Lerp(transform.position - playerTransform.position, targetOffset, smoothSpeed * Time.deltaTime);

            Vector3 desiredPosition = playerTransform.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Gradually adjust the rotation angles
            Quaternion targetRotation = Quaternion.Euler(Vector3.zero);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
