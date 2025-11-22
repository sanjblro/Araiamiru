using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed = 2f;       // movement speed
    public float moveRange = 3f;   // how far left and right the boat moves

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
