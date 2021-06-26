using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] DialogueManager dialogueManager = null;
    [SerializeField] private bool hasChatStarted = false;
    [SerializeField] InputReader reader = null;

    public void StartChat()
    {
        if (hasChatStarted)
        {
            OnTalk();
        }
        else
        {
            reader.EnableDialogueInput();
            hasChatStarted = true;
            dialogueManager.Initialize(dialogue);
        }
    }

    public void OnTalk()
    {
        dialogue = dialogueManager.currentDialogue;
        hasChatStarted = dialogueManager.PushText();
        if (hasChatStarted == false)
        {
            if (dialogue.responses.Count > 0)
            {
                dialogueManager.SetButtons();
                hasChatStarted = true;
            }
            else
            {
                reader.EnablePlayerInput();
            }
        }
    }



}
