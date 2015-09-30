using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class SingleDialogueNode : BaseDialogueNode
{
    public string m_singleMessage;
    
    public BaseDialogueNode m_nextDialogue;

    private GameObject m_dialoguePanel;

    public UnityEvent OnDialogFinished;

    public override void OnEnabled()
    {
        
    }

    public override DialogueTreeStates OnAction()
    {
        if(m_dialoguePanel == null)
        {
            InitializeDialoguePanel();
        }

        return m_currentState;
    }

    public override BaseDialogueNode GetNextDialogue()
    {
        Destroy(m_dialoguePanel);
        return m_nextDialogue;
    }

    protected override void InitializeDialoguePanel()
    {
        m_currentState = DialogueTreeStates.RUNNING;

        m_dialoguePanel = Instantiate((GameObject)Resources.Load("DialoguePanel", typeof(GameObject)));
        Text[] messages = m_dialoguePanel.GetComponentsInChildren<Text>();

        for(int i=0; i<messages.Length;i++)
        {
            if(messages[i].gameObject.name == "Message")
            {
                messages[i].text = m_singleMessage;
                break;
            }

        }

        Button[] buttons = m_dialoguePanel.GetComponentsInChildren<Button>();

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
        if (OnDialogFinished != null)
        {
            OnDialogFinished.Invoke();
        }
        m_currentState = DialogueTreeStates.SUCCESS;
    }
}
