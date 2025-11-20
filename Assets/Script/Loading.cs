using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Loading : MonoBehaviour
{
    public Slider progressBar;             // Progress Bar
    public static string nextSceneName = "Lv1"; // Scene ถัดไป
    public float loadDuration = 3f;        // เวลาที่ Progress Bar จะโหลดเต็ม (วินาที)

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        float timer = 0f;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            timer += Time.deltaTime;

            // Progress Bar แบบจำลอง ขยับช้า ๆ
            float progress = Mathf.Clamp01(timer / loadDuration);
            progressBar.value = progress;

            // ถ้า Async โหลดเสร็จและ Progress Bar เต็ม
            if (timer >= loadDuration && op.progress >= 0.9f)
            {
                progressBar.value = 1f;
                yield return new WaitForSeconds(0.2f); // ดีเลย์เล็กน้อย
                op.allowSceneActivation = true;        // โหลด Scene จริง
            }

            yield return null;
        }
    }
}