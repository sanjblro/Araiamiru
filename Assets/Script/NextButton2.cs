using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton2 : MonoBehaviour
{
    public string sceneToLoad; // ใส่ชื่อ scene ที่ต้องการไป

    public void GoToNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
