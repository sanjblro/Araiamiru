using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int scoreGoal = 10;

    public TextMeshProUGUI scoreText;  // เปลี่ยนจาก Text → TMP
    public GameObject nextLevelUI;     // UI ที่แสดงเมื่อครบ 10 คะแนน

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
        nextLevelUI.SetActive(false); // ซ่อน UI ตอนเริ่มเกม
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
            scoreText.text = score.ToString(); // แสดงคะแนนใหม่
    }

    void ShowNextLevelUI()
    {
        nextLevelUI.SetActive(true);
    }
}


