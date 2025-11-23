using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager2 : MonoBehaviour
{
    public static ScoreManager2 Instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject winButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        score = 0;
        UpdateUI();
        winButton.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();

        if (score >= 10)
        {
            winButton.SetActive(true);
        }
    }

    void UpdateUI()
    {
        scoreText.text = "" + score;

    }
}
