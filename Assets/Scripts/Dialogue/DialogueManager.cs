using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text targetName;
    [SerializeField] Text targetText;
    [SerializeField] Button option1;
    [SerializeField] Button option2;
    [Range(0f, 1f)]
    [SerializeField] float visableTextPercentage;
    [SerializeField] float timerPerLetter = .05f;
    float totalTime, currentTime;
    string currentLine;

    Dialogue currentDialogue;
    int currentLineNum;

    [SerializeField] InputReader reader;

    public void FixedUpdate()
    {
        TypeOutText();
    }

    public bool PushText()
    {
        Debug.Log("Push Text Current Dialogue options count: " + currentDialogue.dialogue.Count);
        Debug.Log("Push Text currentLineNum: " + currentLineNum);
        if (visableTextPercentage < 1f)
        {
            Debug.Log("Reached First");
            visableTextPercentage = 1f;
            UpdateText();
            return true;
        }
        if (currentLineNum >= currentDialogue.dialogue.Count)
        {
            Debug.Log("Being Reached");
            Conclude();
            return false;
        }
        else
        {
            Cycle();
            return true ;
        }
    }

    private void Cycle()
    {

        currentLine = currentDialogue.dialogue[currentLineNum];
        totalTime = currentLine.Length * timerPerLetter;
        currentTime = 0f;
        visableTextPercentage = 0f;
        targetText.text = "";
        currentLineNum++;
    }

    public void TypeOutText()
    {
        if (visableTextPercentage >= 1f) { return; }

        currentTime += Time.deltaTime;
        visableTextPercentage = currentTime / totalTime;
        visableTextPercentage = Mathf.Clamp(visableTextPercentage, 0, 1f);
        UpdateText();
    }

    private void UpdateText()
    {
        int letterCount = (int)(currentLine.Length * visableTextPercentage);
        targetText.text = currentLine.Substring(0, letterCount);
    }

    public void Initialize(Dialogue dialogue)
    {
        Show(true);
        currentDialogue = dialogue;
        currentLineNum = 0;
        targetName.text = currentDialogue.Name;
        Cycle();
    }

    private void Conclude()
    {
        Debug.Log("Conclude method. Current Dialogue Response Count: " + currentDialogue.responses.Count);
        if (currentDialogue.responses.Count < 1)
        {
            Show(false);
            reader.EnablePlayerInput();
        }
        else
        {
            option1.GetComponentInChildren<Text>().text = currentDialogue.responses[0].ResponsibleDialogue;
            option2.GetComponentInChildren<Text>().text = currentDialogue.responses[1].ResponsibleDialogue;
            ButtonHelper(true);

        }
    }

    private void Show(bool conditonal)
    {
        gameObject.SetActive(conditonal);
    }


    public void Option1()
    {
        reader.EnableDialogueInput();
        currentDialogue = currentDialogue.responses[0].Dialogue;
        Debug.Log("Option 1 Current Dialogue options count: " + currentDialogue.responses.Count);
        currentLineNum = 0;
        targetName.text = currentDialogue.Name;
        ButtonHelper(false);
        Cycle();
    }

    public void Option2()
    {
        reader.EnableDialogueInput();
        currentDialogue = currentDialogue.responses[1].Dialogue;
        currentLineNum = 0;
        targetName.text = currentDialogue.Name;
        ButtonHelper(false);
        Cycle();
    }

    private void ButtonHelper(bool onOrOff)
    {
        option1.gameObject.SetActive(onOrOff);
        option2.gameObject.SetActive(onOrOff);
    }
}
