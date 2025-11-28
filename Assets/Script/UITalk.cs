using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UITalk : MonoBehaviour
{
    public Image characterImage;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.03f;

    private DialogueLine[] lines;
    private int index;
    private Coroutine typing;

    // อ้างอิงแบบปลอดภัย: หาได้ทั้ง Move และ FallMove
    private Move moveComp;
    private FallMove fallMoveComp;

    void Awake()
    {
        moveComp = FindObjectOfType<Move>();
        fallMoveComp = FindObjectOfType<FallMove>();
    }

    void Update()
    {
        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Next();
        }
    }

    public void StartDialogue(DialogueLine[] dialogueLines)
    {
        lines = dialogueLines;
        index = 0;

        // หยุดการเคลื่อนที่ของตัวละคร (ถ้ามี)
        if (moveComp != null) moveComp.canMove = false;
        if (fallMoveComp != null) fallMoveComp.canMove = false;

        ShowLine();
    }

    void ShowLine()
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogWarning("UITalk.ShowLine: lines is null or empty");
            CloseDialogue();
            return;
        }

        if (index >= lines.Length)
        {
            CloseDialogue();
            return;
        }

        // ตั้งชื่อ + รูป NPC ของประโยคนี้
        characterNameText.text = lines[index].characterName;
        characterImage.sprite = lines[index].characterPortrait;

        if (typing != null)
            StopCoroutine(typing);

        typing = StartCoroutine(TypeLine(lines[index].text));
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Next()
    {
        index++;
        ShowLine();
    }

    void CloseDialogue()
    {
        gameObject.SetActive(false);

        // ให้เดินต่อ (ถ้ามี)
        if (moveComp != null) moveComp.canMove = true;
        if (fallMoveComp != null) fallMoveComp.canMove = true;
    }
}
