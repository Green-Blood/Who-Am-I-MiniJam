using System;
using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class SkipButton : MonoBehaviour
{
    [SerializeField] private StandardDialogueUI dialogueUI;
    [SerializeField] private UnityUITypewriterEffect typewriter;
    [SerializeField] private float fastCharPerSecond = 250;


    private float minSubtitleSeconds = 2;
    private float subtitleCharsPerSec = 30;
    private float typewriterCharsPerSec = 50;

    public bool skip;

    private void Start()
    {
        // Save original values:
        minSubtitleSeconds = DialogueManager.DisplaySettings.subtitleSettings.minSubtitleSeconds;
        subtitleCharsPerSec = DialogueManager.DisplaySettings.subtitleSettings.subtitleCharsPerSecond;
        typewriterCharsPerSec = typewriter.charactersPerSecond;
    }

    private void SkipToResponseMenu()
    {
        skip = true;

        // Set values to fast forward:
        typewriter.charactersPerSecond = 200;
        DialogueManager.DisplaySettings.subtitleSettings.subtitleCharsPerSecond = fastCharPerSecond;
        DialogueManager.DisplaySettings.subtitleSettings.minSubtitleSeconds = 0;
        DialogueManager.DisplaySettings.subtitleSettings.continueButton =
            DisplaySettings.SubtitleSettings.ContinueButtonMode.Never;
        // Skip this line:
        dialogueUI.OnContinue();
    }

    private void OnConversationResponseMenu(Response[] responses)
    {
        // Set original values:
        typewriter.charactersPerSecond = typewriterCharsPerSec;
        DialogueManager.DisplaySettings.subtitleSettings.subtitleCharsPerSecond = subtitleCharsPerSec;
        DialogueManager.DisplaySettings.subtitleSettings.minSubtitleSeconds = minSubtitleSeconds;
        DialogueManager.DisplaySettings.subtitleSettings.continueButton =
            DisplaySettings.SubtitleSettings.ContinueButtonMode.Always;
    }

    private void OnConversationEnd(Transform actor) => skip = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Left control pressed");
            StartSkipping();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("Left control released");
            StopSkipping();
        }
    }

    private void StartSkipping()
    {
        if (DialogueManager.IsConversationActive)
        {
            Debug.Log("Starting to skip...");
            SkipToResponseMenu();
        }
    }

    private void StopSkipping()
    {
        Debug.Log("Stopping to skip...");
        OnConversationResponseMenu(null);
    }

    private void OnDisable() => StopSkipping();
}