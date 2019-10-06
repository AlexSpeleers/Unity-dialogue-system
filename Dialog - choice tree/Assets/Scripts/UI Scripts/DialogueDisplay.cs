using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class DialogueDisplay : MonoBehaviour
{
    public static DialogueDisplay instance; 
    public Dialogue dialogueSO;
    public Text DialogText;
    public Text NpcNameText;
    public GameObject returnButton;
    [HideInInspector] public int activeLineIndex;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        activeLineIndex = 0;
    }
    private void Update()
    {
        DialogueDriver();
    }

    private void DialogueDriver()
    {
        if (Interaction.instance.dialoguePrefab.active)
        {
            try
            {
                if (activeLineIndex < Interaction.instance.triggeringNpc.GetComponent<DialogueDataHolder>().dialogue.lines.Length - 1)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        activeLineIndex++;
                        SetValuesInDialogTextBoxes(activeLineIndex);
                    }
                }
                else
                {
                    returnButton.SetActive(true);
                }
            }
            catch (NullReferenceException)
            {
                //ignore exeption in line 36 when player leave trigger zone
            }
        }
    }

    public void SetValuesInDialogTextBoxes(int PhraseNumber)
    {
        NpcNameText.text = Interaction.instance.triggeringNpc.GetComponent<DialogueDataHolder>().npc.name;
        DialogText.text = Interaction.instance.triggeringNpc.GetComponent<DialogueDataHolder>().dialogue.lines[PhraseNumber].text;
    }

    public void ReturnButton()
    {
        returnButton.SetActive(false);
        activeLineIndex = 0;
        SetValuesInDialogTextBoxes(activeLineIndex);
    }
    
}
