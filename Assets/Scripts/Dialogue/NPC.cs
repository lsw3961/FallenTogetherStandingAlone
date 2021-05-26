using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] private bool buffer;
    [SerializeField] private bool hasChatStarted = false;
    [SerializeField] InputReader reader;

    public void StartChat()
    {
        if (buffer)
        {
            buffer = false;
            return;
        }
        if (hasChatStarted)
        {
            //Debug.Log("Pressing button works");
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
        hasChatStarted = dialogueManager.PushText();
        if (hasChatStarted == false)
        {
            buffer = true;
            reader.EnablePlayerInput();
        }
    }

}
