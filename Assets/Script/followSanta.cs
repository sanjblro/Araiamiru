using UnityEngine;

public class followSanta : MonoBehaviour
{
    public Transform player;   // ลาก Player มาวาง
    public float smoothSpeed = 0.125f;
    public Vector3 offset;     // ตำแหน่งกล้องห่างจาก Player

    void LateUpdate()
    {
        if (player == null) return;

        // กล้องตามเฉพาะแกน X เท่านั้น
        Vector3 targetPos = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
}
