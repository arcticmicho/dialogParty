using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTreeManager : MonoBehaviour {

	// Use this for initialization
    
#region Fields
    public BaseDialogueNode Head;
    private BaseDialogueNode actualNode;
    public List<BaseDialogueNode> Nodes = new List<BaseDialogueNode>();
#endregion
    void Start () 
    {
        
	}

    void OnEnable()
    {
        if(Nodes != null)
        {
            int count = Nodes.Count;
            for(int i=0; i<count; i++)
            {
                Nodes[i].OnEnabled();
            }
        }
        actualNode = Head;
    }
	
	// Update is called once per frame
	void Update () {

        DialogueTreeStates result = actualNode.OnAction();
        if(result == DialogueTreeStates.SUCCESS)
        {
            actualNode = actualNode.GetNextDialogue();
        }else if(result == DialogueTreeStates.FAILURE)
        {
            //TODO: Finish the Dialogue;
        }
	}
}

public enum DialogueTreeStates
{
    SUCCESS = 0,
    FAILURE = 1,
    RUNNING = 2
}
