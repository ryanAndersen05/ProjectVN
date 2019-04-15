using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles all the logic when in a dialogue state.
/// </summary>
public class DialogueManagerUI : MonoBehaviour
{
    #region const variables
    private const string SELECT_BUTTON = "Submit";
    #endregion const variables

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

    [Header("Dialogue UI Settings")]
    public int lettersPerSecond = 10;

    private DialogueEvent currentlyAssignedDialogueEvent;
    [Tooltip("Animator component that will drive certain animation events within our dialogue manager")]
    private Animator anim;
    private bool isDrawingText;


    private void Awake()
    {
        instance = this;
        CloseDialogueManagerUI();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(SELECT_BUTTON) && !isDrawingText)
        {
            DrawNextDialogueNode(currentlyAssignedDialogueEvent.GetNextDialogueNode());
        }
    }
    #endregion monobehaviour methods
    private void DrawNextDialogueNode(DialogueEvent.DialogueNode dialogueNode)
    {
        if (dialogueNode == null)
        {
            CloseDialogueManagerUI();
            return;
        }
        StartCoroutine(DrawOutTextToTextBox(dialogueNode.dialogue));
    }

    /// <summary>
    /// Opens the dialuge UI
    /// </summary>
    public void OpenDialogueManagerUI(DialogueEvent dialogueEvent)
    {
        dialogueTextContainer.gameObject.SetActive(true);
        this.enabled = true;
        this.currentlyAssignedDialogueEvent = dialogueEvent;
        DrawNextDialogueNode(dialogueEvent.ResetDialogueEvent());
    }

    /// <summary>
    /// Safely closes the dialogue manager and takes care of any actions needed upon closing the dialogue menu
    /// </summary>
    public void CloseDialogueManagerUI()
    {
        dialogueTextContainer.gameObject.SetActive(false);
        this.enabled = false;
    }

    private IEnumerator DrawOutTextToTextBox(string textToDraw)
    {
        isDrawingText = true;

        float timeThatHasPassed = 0;
        float timeToWaitBetweenLetters = 1f / lettersPerSecond;
        string textDrawnSoFar = "";

        while (textDrawnSoFar.Length != textToDraw.Length)
        {
            timeThatHasPassed += Time.deltaTime;
            yield return null;
            if (Input.GetButtonDown(SELECT_BUTTON))
            {
                textDrawnSoFar = textToDraw;
                dialogueText.text = textToDraw;

            }
            else if (timeThatHasPassed > timeToWaitBetweenLetters)
            {
                textDrawnSoFar = textToDraw.Substring(0, textDrawnSoFar.Length + 1);
                timeThatHasPassed = 0;
                timeToWaitBetweenLetters = 1f / lettersPerSecond;
                dialogueText.text = textDrawnSoFar;
            }
        }
        isDrawingText = false;
        dialogueText.text = textToDraw;
    }
}
