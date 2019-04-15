using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>
public class DialogueEvent : MonoBehaviour
{
    public DialogueNode[] dialogueNodeList = new DialogueNode[1];
    private int index = 0;

    #region monobehaviour methods
    private void Start()
    {
        DialogueManagerUI.Instance.OpenDialogueManagerUI(this);
    }
    #endregion monobehavioue methods

    public DialogueNode ResetDialogueEvent()
    {
        index = 0;
        return dialogueNodeList[index];
    }

    public DialogueNode GetCurrentDialogueNode()
    {
        return dialogueNodeList[index];
    }

    public DialogueNode GetNextDialogueNode()
    {
        index++;
        if (index >= dialogueNodeList.Length)
        {
            index = dialogueNodeList.Length;
            return null;
        }
        return dialogueNodeList[index];
    }

    public DialogueNode GetPreviousNode()
    {
        index--;
        if (index < 0)
        {
            index = 0;
            return null;
        }
        return dialogueNodeList[index];
    }

    public DialogueNode PeekNextNode(int amountToLookAhead)
    {
        int i = index + amountToLookAhead;
        if (i >= dialogueNodeList.Length)
        {
            return null;
        }

        return dialogueNodeList[i];
    }

    public DialogueNode PeekPreviousNode(int amountToGoBack)
    {
        int i = index - amountToGoBack;

        if (i < 0)
        {
            return null;
        }
        return dialogueNodeList[i];
    }


    [System.Serializable]
    public class DialogueNode
    {
        [TextArea(5, 10)]
        public string dialogue;
    }
}
