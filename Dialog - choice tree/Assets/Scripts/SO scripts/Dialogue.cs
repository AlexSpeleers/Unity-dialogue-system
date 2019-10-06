using UnityEngine;

[System.Serializable]
public struct Line
{
    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public NPC npc;
    public Line[] lines;
}
