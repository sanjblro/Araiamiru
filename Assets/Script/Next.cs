using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    [Header("UI Button")]
    public GameObject nextLevelButton; // ปุ่ม Next Level (Drag จาก Canvas)

    [Header("Scene to Load")]
    public string sceneToLoad; // กำหนดชื่อ Scene ที่ต้องการโหลด

    private void Start()
    {
        if (nextLevelButton != null)
            nextLevelButton.SetActive(false); // ซ่อนปุ่มตอนเริ่ม
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ชนกล่องผ่าน!");

            // แสดงปุ่ม Next Level
            if (nextLevelButton != null)
                nextLevelButton.SetActive(true);

            // สั่งหยุด Player
            Move moveScript = other.GetComponent<Move>();
            if (moveScript != null)
                moveScript.canMove = false;

            FallMove fallMove = other.GetComponent<FallMove>();
            if (fallMove != null)
                fallMove.canMove = false;
        }
    }

    // ฟังก์ชันให้ปุ่มเรียกเพื่อไป Scene ที่กำหนด
    public void GoToNextLevel()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load ยังไม่ได้ตั้งค่า!");
        }
    }
}


