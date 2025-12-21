using UnityEngine;
using System.Collections.Generic;

public class DialogueTreeSave
{

    public Dictionary<string, float> variables;

    public Character[] chars;
    public DialogueObjSave[] dialogues;
}

public class DialogueObjSave
{
    public DialogueData data;
    public float[] pos;
    public DialogueObjSave(DialogueData dd, Vector3 p)
    {

        data = dd;
        pos = new float[3] { p.x, p.y, p.z };
    }
}