using UnityEngine;

[System.Serializable]
public class Dialogue // this is called to create a dialogue
{
   public string name;
    [TextArea(3,10)]
    public string[] sentences;
}
