using UnityEngine;

public class BoatMovement2 : MonoBehaviour
{
    public float speed = 2f;
    public float moveRange = 3f;
    private float startX;

    private float lastX;   // เก็บค่า X ของเฟรมที่แล้ว

    void Start()
    {
        startX = transform.position.x;
        lastX = startX;
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        // ตรวจทิศทางการเคลื่อนที่
        if (x > lastX)
        {
            // ขวา
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < lastX)
        {
            // ซ้าย
            transform.localScale = new Vector3(-1, 1, 1);
        }

        lastX = x;
    }
}
