using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // Player
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x;      // กล้องตามแกน X เท่านั้น
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
    }
}
