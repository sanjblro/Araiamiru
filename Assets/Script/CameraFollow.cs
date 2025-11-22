using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.5f;

    void LateUpdate()
    {
        Vector3 desiredPos = new Vector3(
            target.position.x,
            transform.position.y,
            transform.position.z
        );

        // ใช้ Lerpระหว่างตำแหน่งปัจจุบัน → desired (ถูกต้องกว่า)
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
    }
}
