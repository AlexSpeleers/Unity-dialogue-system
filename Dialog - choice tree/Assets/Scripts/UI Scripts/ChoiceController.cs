using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueChangeEvent : UnityEvent<Dialogue> { }
public class ChoiceController : MonoBehaviour
{
    public Choices choice;
    public DialogueChangeEvent dialogueChangeEvent;

    public static ChoiceController AddChoiceButton(Button choiceButtonPrefab, Choices choice, int index)
    {
        Button button = Instantiate(choiceButtonPrefab);
        button.transform.SetParent(choiceButtonPrefab.transform.parent);
        button.name = choice.choiceText;
        button.gameObject.SetActive(true);

        ChoiceController choiceController = button.GetComponent<ChoiceController>();
        choiceController.choice = choice;
        return choiceController;
    }
    private void Start()
    {
        if (dialogueChangeEvent == null)
            dialogueChangeEvent = new DialogueChangeEvent();

        GetComponent<Button>().GetComponentInChildren<Text>().text = choice.choiceText;
    }

    public void MakeChoice()
    {
        dialogueChangeEvent.Invoke(choice.nextDialogue);
    }
}
