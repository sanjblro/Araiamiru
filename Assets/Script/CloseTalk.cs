using UnityEngine;

public class CloseTalk : MonoBehaviour
{
    public GameObject talkUI;
    public Move playerMoveScript;

    public void Close()
    {
        talkUI.SetActive(false);
        playerMoveScript.canMove = true; // เดินต่อ
    }
}
