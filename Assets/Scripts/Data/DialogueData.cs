using UnityEngine;
using System.Collections.Generic;


public struct OptionData
{
    public string title;
    public int id;
}


public class DialogueTree
{
    public Dictionary<string, float> variables;
    public Character[] chars;
    public DialogueData[] dialogues;
}

public struct Character
{
    public int id;
    public string Name;
}

public class DialogueData
{
    public int id;
    public string title;
    public string line;
    public OptionData[] options = new OptionData[0];


    public int[] charIDs;
    public int charCurrentlySpeaking;
    public DialogueData() {
        id = -1;
        title = "Untitled Monologue";
        line = "";
        options = new OptionData[0];
        charIDs = new int[1];
        charCurrentlySpeaking = -1;
    }
    public DialogueData(DialogueData dd) {
        
        id = dd.id;
        title = dd.title;
        line = dd.line;
        options = dd.options ;
        charIDs = dd.charIDs;
        charCurrentlySpeaking = dd.charCurrentlySpeaking;
    }

}
