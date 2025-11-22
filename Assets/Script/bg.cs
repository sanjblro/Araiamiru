using UnityEngine;

public class bg : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // จำตำแหน่งแรก
    }

    void LateUpdate()
    {
        transform.position = startPosition; // ล็อกตำแหน่ง ไม่ให้พื้นหลังขยับ
    }
}

