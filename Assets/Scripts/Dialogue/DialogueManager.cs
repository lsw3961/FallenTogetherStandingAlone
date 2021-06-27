using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_Text targetName = null;
    [SerializeField] TMP_Text targetText = null;
    public Button option1;
    public Button option2;
    [Range(0f, 1f)]
    [SerializeField] float visableTextPercentage;
    [SerializeField] float timerPerLetter = .05f;
    float totalTime, currentTime;
    string currentLine;

    public Dialogue currentDialogue;
    int currentLineNum;

    [SerializeField] InputReader reader = null;

    public void FixedUpdate()
    {
        TypeOutText();
    }

    public bool PushText()
    {
        //Debug.Log("Push Text Current Dialogue options count: " + currentDialogue.dialogue.Count);
        //Debug.Log("Push Text currentLineNum: " + currentLineNum);
        if (visableTextPercentage < 1f)
        {
            //Debug.Log("Reached First");
            visableTextPercentage = 1f;
            UpdateText();
            return true;
        }
        if (currentLineNum >= currentDialogue.dialogue.Count)
        {
            //Debug.Log("Being Reached");
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
        if (currentDialogue.responses.Count == 0)
        {
            Show(false);
            reader.EnablePlayerInput();
        }


    }

    private void Show(bool conditonal)
    {
        gameObject.SetActive(conditonal);
    }

    public void ButtonHelper(bool onOrOff)
    {
        option1.gameObject.SetActive(onOrOff);
        option2.gameObject.SetActive(onOrOff);
    }
    public void SetButtons()
    {
        Debug.Log("Set buttons is being reached");
        option1.GetComponentInChildren<TMP_Text>().text = currentDialogue.responses[0].ResponsibleDialogue;
        option2.GetComponentInChildren<TMP_Text>().text = currentDialogue.responses[1].ResponsibleDialogue;
        ButtonHelper(true);
    }

    public void Option1()
    {
        Debug.Log("Hit");
        if (currentDialogue.responses[0].Dialogue != null)
        {
            currentDialogue = currentDialogue.responses[0].Dialogue;
            ButtonHelper(false);
            Initialize(currentDialogue);
        }
        else
        {
            buttonConclude();
        }
    }

    public void Option2()
    {
        currentDialogue = currentDialogue.responses[1].Dialogue;
        ButtonHelper(false);
        Initialize(currentDialogue);
    }

    public void buttonConclude()
    {
        ButtonHelper(false);
        Show(false);
        reader.EnablePlayerInput();
    }
}
