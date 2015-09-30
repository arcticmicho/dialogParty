using UnityEngine;
using System.Collections;

public class BaseDialogueNode : MonoBehaviour
{
    protected DialogueTreeStates m_currentState;

    public virtual void OnEnabled()
    {

    }

    public virtual DialogueTreeStates OnAction()
    {
        return DialogueTreeStates.SUCCESS;
    }

    public virtual BaseDialogueNode GetNextDialogue()
    {
        return null;
    }

    protected virtual void InitializeDialoguePanel()
    {

    }

}
