using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item")) // ให้ itemPrefab ตั้ง Tag = Item
        {
            ScoreManager.instance.AddScore(1);

            Destroy(other.gameObject); // ลบ item ที่ตกลงกล่องแล้ว
        }
    }
}

