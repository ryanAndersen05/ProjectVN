using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles all the logic when in a dialogue state.
/// </summary>
public class DialogueManagerUI : MonoBehaviour
{
    #region static vairables
    private static DialogueManagerUI instance;

    public static DialogueManagerUI Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<DialogueManagerUI>();
            }
            return instance;
        }
    }
    #endregion static variables

    #region monobehaviour methods
    [Header("UI References")]
    public Text dialogueText;

    public Transform dialogueTextContainer;
    private DialogueEvent currentlyAssignedDialogueEvent;
    [Tooltip("Animator component that will drive certain animation events within our dialogue manager")]
    private Animator anim;


    private void Awake()
    {
        instance = this;
        CloseDialogueManagerUI();
        anim = GetComponent<Animator>();
    }
    #endregion monobehaviour methods


    /// <summary>
    /// Opens the dialuge UI
    /// </summary>
    public void OpenDialogueManagerUI(DialogueEvent dialogueEvent)
    {
        dialogueTextContainer.gameObject.SetActive(true);
        this.enabled = true;
        this.currentlyAssignedDialogueEvent = dialogueEvent;
    }

    /// <summary>
    /// Safely closes the dialogue manager and takes care of any actions needed upon closing the dialogue menu
    /// </summary>
    public void CloseDialogueManagerUI()
    {
        dialogueTextContainer.gameObject.SetActive(false);
        this.enabled = true;
    }
}
