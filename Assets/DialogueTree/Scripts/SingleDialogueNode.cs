using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SingleDialogueNode : BaseDialogueNode
{
    public string SingleMessage;
    
    public BaseDialogueNode nextDialogue;

    private DialogueTreeStates currentState;
    private GameObject dialoguePanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnEnabled()
    {
        
    }

    public override DialogueTreeStates OnAction()
    {
        if(dialoguePanel == null)
        {
            InitializeDialoguePanel();
        }
        Debug.Log(SingleMessage);

        return currentState;
    }

    public override BaseDialogueNode GetNextDialogue()
    {
        Destroy(dialoguePanel);
        return nextDialogue;
    }

    private void InitializeDialoguePanel()
    {
        currentState = DialogueTreeStates.RUNNING;

        dialoguePanel = Instantiate((GameObject)Resources.Load("DialoguePanel", typeof(GameObject)));
        Text[] messages = dialoguePanel.GetComponentsInChildren<Text>();

        for(int i=0; i<messages.Length;i++)
        {
            if(messages[i].gameObject.name == "Message")
            {
                messages[i].text = SingleMessage;
                break;
            }

        }

        Button[] buttons = dialoguePanel.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].gameObject.name == "ButtonOptionA")
            {
                buttons[i].onClick.AddListener(() => OnOptionClicked());
            }
            else if (buttons[i].gameObject.name == "ButtonOptionB")
            {
                buttons[i].onClick.AddListener(() => OnOptionClicked());
            }
        }  
    }

    private void OnOptionClicked()
    {
        currentState = DialogueTreeStates.SUCCESS;
    }
}
