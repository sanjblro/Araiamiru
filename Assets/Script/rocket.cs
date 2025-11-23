using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMPro.TextMeshProUGUI resultText;
    public GameObject nextButton;   // ปุ่มไปด่านต่อไป

    bool gameOver = false;
    bool safeLanding = false;  // ใช้เช็คว่าจอดสำเร็จหรือไม่

    public float fuel = 100f;
    public float fuelUseRate = 20f;
    public UnityEngine.UI.Slider fuelBar;

    public float thrust = 5f;

    public GameObject idleSprite;
    public GameObject fireSprite;

    Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameOver) return;

        float impactSpeed = collision.relativeVelocity.magnitude;

        if (impactSpeed > 5f)
        {
            // Crash
            gameOver = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;

            resultText.text = "CRASH!";
            gameOverPanel.SetActive(true);
            nextButton.SetActive(false);

            Invoke("RestartScene", 1.5f);
        }
        else
        {
            // Safe landing
            gameOver = true;
            safeLanding = true;  // บอกว่า landing สำเร็จ
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;

            resultText.text = "SAFE LANDING!";
            gameOverPanel.SetActive(true);
            nextButton.SetActive(true);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoNextLevel()
    {
        SceneManager.LoadScene("lv2"); // แก้เป็นชื่อ scene ที่ต้องการ
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireSprite.SetActive(false);
        fuelBar.maxValue = fuel;
        fuelBar.value = fuel;

        nextButton.SetActive(false);
    }

    void Update()
    {
        // ⛔ ถ้าจอดสำเร็จ → กด Space เพื่อไปหน้าต่อไป
        if (gameOver && safeLanding)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GoNextLevel();
            }
            return;
        }

        // ถ้า crash หรือยังไม่ gameOver →
        // ทำงานตามปกติ
        if (gameOver) return;

        fuelBar.value = fuel;

        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            rb.AddForce(Vector2.up * thrust);

            idleSprite.SetActive(false);
            fireSprite.SetActive(true);

            fuel -= fuelUseRate * Time.deltaTime;
        }
        else
        {
            idleSprite.SetActive(true);
            fireSprite.SetActive(false);
        }
    }
}

