using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public Button[] buttons; // ปุ่มทั้งหมด 3 ปุ่ม
    int currentIndex = 0;

    public GameObject infoPanel; // UI ที่จะโชว์เมื่อกด Info

    bool isHolding = false;
    float holdTime = 0f;
    public float holdThreshold = 0.5f; // เวลากดค้างเพื่อกดปุ่มจริง

    void Start()
    {
        HighlightButton();
        infoPanel.SetActive(false);
    }

    void Update()
    {
        // ถ้า infoPanel เปิดอยู่ → กด spacebar = ปิดทันที
        if (infoPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                infoPanel.SetActive(false);
            }
            return; // ไม่ให้เลือกปุ่มเมนูตอน infoPanel เปิดอยู่
        }

        // ปกติ: เปลี่ยนปุ่ม หรือกดค้างเพื่อเลือก
        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdTime = 0f;
            isHolding = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            holdTime += Time.deltaTime;

            if (isHolding && holdTime >= holdThreshold)
            {
                isHolding = false;
                ActivateButton();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (holdTime < holdThreshold)
            {
                NextButton();
            }
            isHolding = false;
        }
    }


    void NextButton()
    {
        currentIndex++;
        if (currentIndex >= buttons.Length)
            currentIndex = 0;

        HighlightButton();
    }

    void HighlightButton()
    {
        // ล้างสีเดิมทั้งหมด
        foreach (Button b in buttons)
        {
            b.GetComponent<Image>().color = Color.white;
        }
        // ไฮไลต์ปุ่มปัจจุบัน
        buttons[currentIndex].GetComponent<Image>().color = new Color(0.85f, 0.85f, 0.85f, 1f);
    }

    void ActivateButton()
    {
        string btnName = buttons[currentIndex].name;

        if (btnName == "PlayButton")
        {
            SceneManager.LoadScene("lv4"); // ใส่ชื่อฉากจริงตรงนี้
        }
        else if (btnName == "InfoButton")
        {
            infoPanel.SetActive(true);
        }
        else if (btnName == "QuitButton")
        {
            Application.Quit();
            Debug.Log("Quit Game"); // เผื่อทดสอบใน Editor
        }
    }
}