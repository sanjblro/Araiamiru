using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int scoreGoal = 10;

    public TextMeshProUGUI scoreText;
    public GameObject nextLevelUI; // UI แสดงเมื่อครบ 10 คะแนน

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
        nextLevelUI.SetActive(false);
    }

    void Update()
    {
        // ถ้า UI ขึ้นแล้ว → กด Spacebar ไปต่อได้
        if (nextLevelUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            GoToNextScene();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();

        if (score >= scoreGoal)
        {
            ShowNextLevelUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    void ShowNextLevelUI()
    {
        nextLevelUI.SetActive(true);
    }

    public void GoToNextScene()
    {
        // เรียก NextButton2 เพื่อโหลดฉากต่อไป
        FindObjectOfType<NextButton2>().GoToNextScene();
    }
}



