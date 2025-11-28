using UnityEngine;

public class fly : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float flyHeight = 2f;

    public GameObject itemPrefab;
    public Transform dropPoint;

    private Rigidbody2D rb;

    public bool canFly = true;   // ⭐ ให้ NPCTalkFly สั่งหยุดได้

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (!canFly) return;  // ⭐ หยุดกดปุ่มถ้ากำลังคุย

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropItem();
        }
    }

    void FixedUpdate()
    {
        if (canFly)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb.velocity = Vector2.zero; // ⭐ หยุดนิ่งตอนคุย
        }

        transform.position = new Vector3(transform.position.x, flyHeight, 0);
    }

    void DropItem()
    {
        GameObject item = Instantiate(itemPrefab, dropPoint.position, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        if (itemRb != null)
        {
            itemRb.velocity = Vector2.zero;
            itemRb.angularVelocity = 0f;
            itemRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}


//using UnityEngine;

//public class fly : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    public float flyHeight = 2f;

//    public GameObject itemPrefab;
//    public Transform dropPoint;

//    private Rigidbody2D rb;

//    public bool canFly = true;   // ⭐ เพิ่มตัวนี้เพื่อหยุดตอนคุย

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        rb.gravityScale = 0;
//        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
//    }

//    void Update()
//    {
//        if (!canFly) return;  // ⭐ ไม่ให้กด Space ถ้ากำลังคุย

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            DropItem();
//        }
//    }

//    void FixedUpdate()
//    {
//        if (canFly)
//        {
//            rb.velocity = new Vector2(moveSpeed, 0f);
//        }
//        else
//        {
//            rb.velocity = Vector2.zero; // ⭐ หยุดนิ่งตอนคุย
//        }

//        transform.position = new Vector3(transform.position.x, flyHeight, 0);
//    }

//    void DropItem()
//    {
//        GameObject item = Instantiate(itemPrefab, dropPoint.position, Quaternion.identity);

//        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
//        if (itemRb != null)
//        {
//            itemRb.velocity = Vector2.zero;
//            itemRb.angularVelocity = 0f;
//            itemRb.constraints = RigidbodyConstraints2D.FreezeRotation;
//        }
//    }
//}


