using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // หรือเรียกหน้า Game Over UI ก็ได้
        }
    }
}

