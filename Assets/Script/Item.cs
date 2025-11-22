using UnityEngine;

public class FallItem : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.gravityScale = 1f;           // เปิดให้ตกลง
        rb.freezeRotation = true;       // ล็อกไม่ให้หมุน
    }

    void FixedUpdate()
    {
        // บังคับให้ตกลงเป็นเส้นตรง ไม่มีไหลด้านข้าง
        rb.velocity = new Vector2(0, rb.velocity.y);

        // กันหลุดให้ชัวร์
        rb.angularVelocity = 0;
        rb.rotation = 0;
    }
}

