using UnityEngine;

public class NPCTalk2 : MonoBehaviour
{
    public UITalk talkUI;
    public DialogueLine[] lines;
    public FallMove playerMove;   // เปลี่ยนเป็น FallMove

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMove.canMove = false;    // หยุดเดิน

            talkUI.gameObject.SetActive(true);
            talkUI.StartDialogue(lines);
        }
    }
}
