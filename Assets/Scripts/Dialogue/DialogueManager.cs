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

    public void PushText()
    {
        if (visableTextPercentage < 1f)
        {
            visableTextPercentage = 1f;
            UpdateText();
            return;
        }
        if (currentLineNum >= currentDialogue.dialogue.Count)
        {
            Conclude();
            return;
        }
        else
        {
            Cycle();
            return;
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
        if (currentDialogue.responses.Count < 1)
        {
            Show(false);
        }
        else
        {
            option1.GetComponentInChildren<Text>().text = currentDialogue.responses[0].ResponsibleDialogue;
            option2.GetComponentInChildren<Text>().text = currentDialogue.responses[1].ResponsibleDialogue;
            option1.gameObject.SetActive(true);
            option2.gameObject.SetActive(true);

        }
    }

    private void Show(bool conditonal)
    {
        gameObject.SetActive(conditonal);

    }


    public void Option1()
    {
        currentDialogue = currentDialogue.responses[0].Dialogue;
        currentLineNum = 0;
        targetName.text = currentDialogue.Name;
        Cycle();
    }

    public void Option2()
    {
        currentDialogue = currentDialogue.responses[1].Dialogue;
        currentLineNum = 0;
        targetName.text = currentDialogue.Name;
        Cycle();
    }
}
