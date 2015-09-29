using UnityEngine;
using System.Collections;

public class BaseDialogueNode : MonoBehaviour
{


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

}
