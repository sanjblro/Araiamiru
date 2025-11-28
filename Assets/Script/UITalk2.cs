using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UITalk2 : MonoBehaviour
{
    public Image characterImage;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.03f;

    private DialogueLine[] lines;
    private int index;

    private Coroutine typing;

    private fly playerFly;   // ⬅⭐ เก็บไว้เพื่อสั่งบินต่อหลังคุยเสร็จ

    void Update()
    {
        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Next();
        }
    }

    // ⬅⭐ เพิ่มตัวรับ playerFly ด้วย
    public void StartDialogue(DialogueLine[] dialogueLines, fly player)
    {
        lines = dialogueLines;
        index = 0;

        playerFly = player;        // ⭐ เก็บ reference
        playerFly.canFly = false;  // ⭐ หยุดบิน

        ShowLine();
    }

    void ShowLine()
    {
        if (lines == null || lines.Length == 0)
        {
            CloseDialogue();
            return;
        }

        if (index >= lines.Length)
        {
            CloseDialogue();
            return;
        }

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

        // ⭐ คุยเสร็จ → บินต่อได้
        if (playerFly != null)
            playerFly.canFly = true;
    }
}
