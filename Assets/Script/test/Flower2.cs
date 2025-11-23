using UnityEngine;

public class Flower2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Boat"))
        {
            ScoreManager2.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
