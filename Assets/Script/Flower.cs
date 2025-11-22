using UnityEngine;

public class Flower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boat"))
        {
            if (ScoreSystem.instance != null)
            {
                ScoreSystem.instance.AddPoint();
            }

            Destroy(gameObject);
        }
    }
}
