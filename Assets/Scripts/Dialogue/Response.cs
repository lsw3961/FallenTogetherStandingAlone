using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Response", menuName = "Dialogue/Response")]
public class Response : ScriptableObject
{
    [TextArea]
    string responseDialogue;
    Dialogue dialogue;


}
