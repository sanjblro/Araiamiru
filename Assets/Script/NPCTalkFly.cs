using UnityEngine;

public class NPCTalkFly : MonoBehaviour
{
    public UITalk2 talkUI;          // ลาก UI Dialogue มาใส่
    public DialogueLine[] lines;   // แบทช์บทพูด
    public fly playerFly;          // ลาก Player (ที่มี fly.cs) มาใส่

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ⭐ หยุดบินตอนเริ่มคุย
            playerFly.canFly = false;

            // เปิด UI
            talkUI.gameObject.SetActive(true);

            // ส่งชุดบทสนทนาไปให้ UI
            talkUI.StartDialogue(lines, playerFly);
        }
    }
}
