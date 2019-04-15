using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Extends Dialogue Event, but this one will allow the player to make a multiple choice decision if needed.
/// </summary>
public class DialogueEventMultiple : DialogueEvent
{
    [System.Serializable]
    public class DialogueNodeMultiple : DialogueNode
    {
        public bool openChoice;
        public int choiceToOpen;
    }

    [System.Serializable]
    public class DialogueNodeChoice
    {
        [Tooltip("The text that will be displayed for this option")]
        public string optionTextOption;
        [Tooltip("Upon selecting this option, you will jump to this location in the dialogue event list")]
        public int dialogueIndexToJumpTo;
    }
}
