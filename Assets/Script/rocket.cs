using UnityEngine;

public class RocketController : MonoBehaviour
{

    public GameObject gameOverPanel;
    public TMPro.TextMeshProUGUI resultText;

    bool gameOver = false;

    public float fuel = 100f;        // starting fuel
    public float fuelUseRate = 20f;  // fuel per second
    public UnityEngine.UI.Slider fuelBar;

    public float thrust = 5f;

    public GameObject idleSprite;
    public GameObject fireSprite;

    Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameOver) return;

        float impactSpeed = collision.relativeVelocity.magnitude;
        Debug.Log("Impact Speed: " + impactSpeed);

        if (impactSpeed > 5f)
        {
            // Crash
            gameOver = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;

            resultText.text = "CRASH! 💥";
            gameOverPanel.SetActive(true);
        }
        else
        {
            // Safe landing
            gameOver = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;

            resultText.text = "SAFE LANDING! 🟢";
            gameOverPanel.SetActive(true);

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireSprite.SetActive(false);   // start with idle
        fuelBar.maxValue = fuel;
        fuelBar.value = fuel;
    }

    void Update()
    {
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
