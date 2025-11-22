using UnityEngine;
using UnityEngine.SceneManagement;

public class Dropzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            ScoreManager.instance.AddScore(1); // บวกคะแนน 1
            Destroy(other.gameObject); // ลบไอเท็มเมื่อเก็บแล้ว
        }
    }
}

