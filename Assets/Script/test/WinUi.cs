using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUi: MonoBehaviour
{
    public string nextSceneName;

    void Update()
    {
        // ถ้า UI ยังไม่เปิด → ไม่ทำอะไร
        if (!gameObject.activeSelf)
            return;

        // ถ้า UI เปิด และกด Space → ไปฉากต่อไป
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

