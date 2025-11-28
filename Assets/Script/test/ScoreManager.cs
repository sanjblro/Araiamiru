using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager2 : MonoBehaviour
{
    public static ScoreManager2 Instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject winButton;

    // ⭐ เพิ่มระบบเรือ
    public GameObject boat;         // เรือลากเข้ามาใส่
    public Transform boatTarget;    // จุดที่ให้เรือหยุด
    public float boatSpeed = 2f;    // ความเร็วเรือ
    private bool boatMove = false;  // เช็คว่าเรือกำลังวิ่งไหม

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

        if (boat != null)
            boat.SetActive(false); // ⭐ เริ่มเกมให้เรือซ่อนไว้
    }

    void Update()
    {
        // ⭐ ให้เรือวิ่งเฉย ๆ ไม่ยุ่งระบบอื่น
        if (boatMove && boat != null && boatTarget != null)
        {
            boat.transform.position = Vector3.MoveTowards(
                boat.transform.position,
                boatTarget.position,
                boatSpeed * Time.deltaTime
            );

            // ⭐ ถึงตำแหน่งแล้วหยุดเฉย ๆ
            if (Vector3.Distance(boat.transform.position, boatTarget.position) < 0.1f)
            {
                boatMove = false;
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();

        if (score >= 10)
        {
            winButton.SetActive(true);   // ⭐ ใช้เหมือนเดิม

            // ⭐ ทำให้เรือโผล่แล้ววิ่งเข้ามา
            if (boat != null)
            {
                boat.SetActive(true);  // โผล่เรือ
                boatMove = true;       // เริ่มวิ่ง
            }
        }
    }

    void UpdateUI()
    {
        scoreText.text = "" + score;
    }
}
