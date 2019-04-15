using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Awake()
    {
        instance = this;
    }
    #endregion monobehaviour methods


    /// <summary>
    /// Opens the dialuge UI
    /// </summary>
    private void OpenDialogueManagerUI()
    {
        this.gameObject.SetActive(true);
    }


    /// <summary>
    /// Safely closes the dialogue manager and takes care of any actions needed upon closing the dialogue menu
    /// </summary>
    private void CloseDialogueManagerUI()
    {
        this.gameObject.SetActive(false);
    }
}
