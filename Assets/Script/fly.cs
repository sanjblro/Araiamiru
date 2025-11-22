using UnityEngine;

public class fly : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float flyHeight = 2f;

    public GameObject itemPrefab;
    public Transform dropPoint;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropItem();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);

        transform.position = new Vector3(transform.position.x, flyHeight, 0);
    }

    void DropItem()
    {
        GameObject item = Instantiate(itemPrefab, dropPoint.position, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        if (itemRb != null)
        {
            itemRb.velocity = Vector2.zero;        // ไม่รับแรงจาก UFO
            itemRb.angularVelocity = 0f;
            itemRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

}

