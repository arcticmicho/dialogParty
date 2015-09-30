using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class DecisionDialogueNode : BaseDialogueNode
{

    public BaseDialogueNode optionA;
    public BaseDialogueNode optionB;

    public string SingleMessage;
    public string OptionMessageA;
    public string OptionMessageB;

    private BaseDialogueNode nextDialogue;
    private GameObject dialoguePanel;

    public UnityEvent OnOptionASelected;
    public UnityEvent OnOptionBSelected;

    public override void OnEnabled()
    {

    }

    public override DialogueTreeStates OnAction()
    {
        Debug.Log(OptionMessageA);
        if (dialoguePanel == null)
        {
            InitializeDialoguePanel();
        }
        return m_currentState;
    }

    public override BaseDialogueNode GetNextDialogue()
    {
        Destroy(dialoguePanel);
        return nextDialogue;
    }

    protected override void InitializeDialoguePanel()
    {
        m_currentState = DialogueTreeStates.RUNNING;

        dialoguePanel = Instantiate((GameObject)Resources.Load("DialoguePanel", typeof(GameObject)));
        Text[] messages = dialoguePanel.GetComponentsInChildren<Text>();

        for (int i = 0; i < messages.Length; i++)
        {
            if (messages[i].gameObject.name == "Message")
            {
                messages[i].text = SingleMessage;

            }
            else if (messages[i].gameObject.name == "MessageOptionA")
            {
                messages[i].text = OptionMessageA;
            }
            else if(messages[i].gameObject.name == "MessageOptionB")
            {
                messages[i].text = OptionMessageB;
            }
        }

        Button[] buttons = dialoguePanel.GetComponentsInChildren<Button>();

        for(int i=0; i<buttons.Length; i++)
        {
            if(buttons[i].gameObject.name == "ButtonOptionA")
            {
                buttons[i].onClick.AddListener(() => OnOptionAClicked());
            }
            else if(buttons[i].gameObject.name == "ButtonOptionB")
            {
                buttons[i].onClick.AddListener(() => OnOptionBClicked());
            }
        }    
    }

    private void OnOptionAClicked()
    {
        m_currentState = DialogueTreeStates.SUCCESS;
        nextDialogue = optionA;
        if(OnOptionASelected != null)
        {
            OnOptionASelected.Invoke();
        }
    }

    private void OnOptionBClicked()
    {
        m_currentState = DialogueTreeStates.SUCCESS;
        nextDialogue = optionB;
        if (OnOptionBSelected != null)
        {
            OnOptionBSelected.Invoke();
        }
    }
}
