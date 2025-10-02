using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class CharacterDisplayManager : MonoBehaviour
{

    public TMP_Dropdown charNoSel;
    public TMP_Dropdown charSel;
    public Toggle speakSel;
    public int currChar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void init() { 
        currChar = 0;
        if (EditPanelManager.inst.currentlyEditing.dd.charIDs.Length == 0) {
            EditPanelManager.inst.currentlyEditing.dd.charIDs = new int[1];
        }
        if (EditPanelManager.inst.currentlyEditing.dd.charCurrentlySpeaking < 0) {
            EditPanelManager.inst.currentlyEditing.dd.charCurrentlySpeaking = 0;
        }
        updateDisplay();
    }

    void updateDisplay() {
        charNoSel.ClearOptions();
        List<string> t = genChooseTitles(EditPanelManager.inst.currentlyEditing.dd.charIDs.Length);
        charNoSel.value = currChar;
        charNoSel.AddOptions(t);
        charSel.ClearOptions();
        charSel.AddOptions(genCharTitles(DialogueTreeManager.tree.chars.ToArray()));
        charSel.value = EditPanelManager.inst.currentlyEditing.dd.charIDs[currChar];
        speakSel.isOn = currChar == EditPanelManager.inst.currentlyEditing.dd.charCurrentlySpeaking;
    }
    List<string> genCharTitles(Character[] op)
    {
        List<string> temp = new List<string>();
        foreach (Character o in op)
        {
            temp.Add(o.Name);
        }
        return temp;
    }
    List<string> genChooseTitles(int op)
    {
        List<string> temp = new List<string>();
        for (int i = 0; i<op; i++)
        {
            temp.Add("Character "+ i.ToString());
        }
        return temp;
    }
    public void AddCharacter()
    {
        int[] temp = new int[EditPanelManager.inst.currentlyEditing.dd.charIDs.Length + 1];
        for (int i = 0; i < EditPanelManager.inst.currentlyEditing.dd.charIDs.Length; i++)
        {
            temp[i] = EditPanelManager.inst.currentlyEditing.dd.charIDs[i];
        }
        temp[EditPanelManager.inst.currentlyEditing.dd.charIDs.Length] = 0;
        EditPanelManager.inst.currentlyEditing.dd.charIDs = temp;
        updateDisplay();
        changeCurrent(temp.Length - 1);
    }
    public void changeCurrent(int c) {
        currChar = c;
        charNoSel.value = currChar;
        charSel.value = EditPanelManager.inst.currentlyEditing.dd.charIDs[currChar];
        speakSel.isOn = currChar == EditPanelManager.inst.currentlyEditing.dd.charCurrentlySpeaking;
    }

    public void RemoveCharacter()
    {
        if (EditPanelManager.inst.currentlyEditing.dd.charIDs.Length == 1) {
            return;
        }
        int[] temp = new int[EditPanelManager.inst.currentlyEditing.dd.charIDs.Length - 1];
        int j = 0;
        for (int i = 0; i < EditPanelManager.inst.currentlyEditing.dd.charIDs.Length; i++)
        {
            if (j == currChar) {
                continue;
            }
            temp[j] = EditPanelManager.inst.currentlyEditing.dd.charIDs[i];
            j++;
        }
        currChar -= 1;
        int t = currChar;
        EditPanelManager.inst.currentlyEditing.dd.charIDs = temp;
        updateDisplay();
        changeCurrent(t);
    }
    public void EditCharacter(int id,int value)
    {
        EditPanelManager.inst.currentlyEditing.dd.charIDs[id] = value;
    }
    public void EditSpeaking(int id)
    {
        EditPanelManager.inst.currentlyEditing.dd.charCurrentlySpeaking = id;
    }

    public void editchar(int value)
    {
        EditCharacter(currChar, value);
    }
    public void currentlySpeaking(bool t)
    {
        if (t)
        {
            EditSpeaking(currChar);
        }
    }
}
