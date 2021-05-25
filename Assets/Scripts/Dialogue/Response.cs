using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Response", menuName = "Dialogue/Response")]
public class Response : ScriptableObject
{

    [SerializeField]
    string responseDialogue;
    [SerializeField]
    Dialogue dialogue;

    public string ResponsibleDialogue
    {
        get { return responseDialogue; }
    }

    public Dialogue Dialogue
    {
        get { return dialogue; }
    }

}
