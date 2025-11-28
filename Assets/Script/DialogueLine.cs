using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public Sprite characterPortrait;

    [TextArea(2, 4)]
    public string text;
}
