using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    [Header("UI Indicator")]
    public GameObject nextLevelButton; // ใช้แค่เป็นตัวโชว์ว่าพร้อมไปต่อ

    [Header("Scene to Load")]
    public string sceneToLoad;

    bool canGoNext = false; // ใช้ตรวจว่าผ่าน Trigger แล้ว

    private void Start()
    {
        if (nextLevelButton != null)
            nextLevelButton.SetActive(false);
    }

    private void Update()
    {
        // ถ้าอยู่ในโซน + กด spacebar = ไปด่านต่อ
        if (canGoNext && Input.GetKeyDown(KeyCode.Space))
        {
            GoToNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ชนจุดผ่านระดับ!");

            // แสดงปุ่มเฉย ๆ เป็น UI indicator
            if (nextLevelButton != null)
                nextLevelButton.SetActive(true);

            canGoNext = true;

            // หยุดตัวละคร
            Move moveScript = other.GetComponent<Move>();
            if (moveScript != null)
                moveScript.canMove = false;

            FallMove fallMove = other.GetComponent<FallMove>();
            if (fallMove != null)
                fallMove.canMove = false;
        }
    }

    void GoToNextLevel()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load ยังไม่ได้ตั้งชื่อ!");
        }
    }
}


