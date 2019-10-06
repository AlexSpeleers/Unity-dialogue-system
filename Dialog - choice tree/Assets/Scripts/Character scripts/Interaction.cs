using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public static Interaction instance;
    [HideInInspector]
    public GameObject triggeringNpc;
    public Text triggerLabel;
    [HideInInspector]
    public bool isTriggering;
    private bool isOnce;

    [Header("Dialog UI")]
    public GameObject dialoguePrefab;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        isTriggering = false;
        triggerLabel.text = "Press F to interact";
    }

    private void Update()
    {        
        if (isTriggering)
        {
            if (isOnce)
            {
                triggerLabel.transform.localScale = Vector2.one;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                ShowDialog();
            }
        }
        else 
        {
            HideDialog();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            isTriggering = true;
            triggeringNpc = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            isTriggering = false;
            triggeringNpc = null;
        }
    }

    private void ShowDialog()
    {
        //TODO: activate dialogue menu
        isOnce = false;
        triggerLabel.transform.localScale = Vector2.zero;
        dialoguePrefab.SetActive(true);
        DialogueDisplay.instance.SetValuesInDialogTextBoxes(DialogueDisplay.instance.activeLineIndex);
    }
    private void HideDialog()
    {
        isOnce = true;
        dialoguePrefab.SetActive(false);
        triggerLabel.transform.localScale = Vector2.zero;
        DialogueDisplay.instance.activeLineIndex = 0;
    }
}
