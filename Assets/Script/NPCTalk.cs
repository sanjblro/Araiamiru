using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public UITalk talkUI;
    public DialogueLine[] lines;
    public Move playerMove;   // <-- ลาก Player ที่มี Move.cs มาใส่ตรงนี้

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // หยุดตัวละคร
            playerMove.canMove = false;

            // เปิด UI
            talkUI.gameObject.SetActive(true);

            // เริ่มบทสนทนา
            talkUI.StartDialogue(lines);
        }
    }
}

