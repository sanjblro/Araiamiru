using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public string sceneName;   // ใส่ชื่อฉากที่จะไป
    public GameObject showUI;  // UI บอกว่ากด Spacebar เพื่อไปต่อ

    bool canChange = false;

    void Start()
    {
        if (showUI != null)
            showUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canChange = true;

            if (showUI != null)
                showUI.SetActive(true);
        }
    }

    void Update()
    {
        // ถ้าเข้า Trigger แล้ว → กด Spacebar เพื่อไปด่านต่อ
        if (canChange && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

