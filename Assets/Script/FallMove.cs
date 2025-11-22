using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f; // ระยะ Raycast ลงพื้นใต้เท้า
    public float forwardCheckDistance = 0.2f; // ระยะเช็คพื้นข้างหน้า

    [Header("Fall Death")]
    public float fallDeathY = -10f; // ตกต่ำกว่านี้ = Game Over

    private Rigidbody2D rb;
    private Collider2D col;
    public bool canMove = true;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // ล็อกการหมุนไม่ให้ล้ม
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
{
    if (!canMove) return; // ❗ ห้ามเดินหรือกระโดดเมื่อเจอ Trigger

    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    if (transform.position.y < fallDeathY)
    {
        GameOver();
    }
}



    void FixedUpdate()
    {
        if (canMove && IsGroundAhead())
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (!canMove)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // หยุดจริง ๆ
        }
    }

    // ฟังก์ชันเช็คว่าอยู่บนพื้น
    bool IsGrounded()
    {
        Vector2 origin = new Vector2(col.bounds.center.x, col.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    // ฟังก์ชันเช็คว่าพื้นข้างหน้ามีหรือไม่
    bool IsGroundAhead()
    {
        Vector2 origin = new Vector2(col.bounds.center.x + col.bounds.extents.x, col.bounds.min.y); // ขอบเท้าหน้า
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, forwardCheckDistance, groundLayer);
        return hit.collider != null;
    }

    void GameOver()
    {
        Debug.Log("GAME OVER - ตกหลุม");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // วาด Gizmos ช่วยดู Raycast
    void OnDrawGizmos()
    {
        if (col == null) return;

        // Ray ลงพื้นใต้เท้า
        Gizmos.color = Color.green;
        Vector2 origin = new Vector2(col.bounds.center.x, col.bounds.min.y);
        Gizmos.DrawLine(origin, origin + Vector2.down * groundCheckDistance);

        // Ray ข้างหน้า
        Gizmos.color = Color.red;
        Vector2 originFront = new Vector2(col.bounds.center.x + col.bounds.extents.x, col.bounds.min.y);
        Gizmos.DrawLine(originFront, originFront + Vector2.down * forwardCheckDistance);
    }


}