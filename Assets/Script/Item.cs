using UnityEngine;

public class FallingItem : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // ล็อกทุกเฟรมไม่ให้เอียง/ไม่ให้มีแรงด้านข้าง
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.angularVelocity = 0;
        rb.rotation = 0;
    }
}
