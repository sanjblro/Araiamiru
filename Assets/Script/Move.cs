using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;      // ความเร็วเดินคงที่
    public float jumpForce = 10f;     // แรงกระโดด
    public Transform groundCheck;     // จุดเช็คพื้น
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;     // เลเยอร์พื้น

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // เช็คว่าตัวละครยืนบนพื้นหรือไม่
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // กระโดดตอนกด Space และต้องอยู่บนพื้น
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // เดินไปข้างหน้าความเร็วคงที่
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}


