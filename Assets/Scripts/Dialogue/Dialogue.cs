using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea]
    public List<string> dialogue;
    public List<Response> responses;


}
