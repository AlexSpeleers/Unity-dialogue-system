using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public struct Choices
{
    [TextArea(2, 5)]
    public string choiceText;
    public Dialogue nextDialogue;
}

[CreateAssetMenu(fileName = "New choice", menuName = "Choice")]
public class Choice : ScriptableObject
{
    public Choices[] choices;
}
