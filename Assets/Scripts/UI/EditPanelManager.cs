using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class EditPanelManager : MonoBehaviour
{

    public DialogueOBJ currentlyEditing;
    public static EditPanelManager inst;

    public GameObject Panel;
    public TMP_InputField title;
    public TMP_Text id;

    

    public TMP_InputField content;

    public ConnectionDisplayManager cdm;
    public CharacterDisplayManager chardm;
    private void Awake()
    {
        inst = this;


    }

    public void Load(DialogueOBJ d) {
        Panel.SetActive(true);
        Zoom.doZoom = false;
        currentlyEditing = d;
        title.text = currentlyEditing.dd.title;
        id.text = currentlyEditing.dd.id + "";
        content.text = currentlyEditing.dd.line;
        cdm.init();
        chardm.init();
    }

    public void onClosePanel() {
        Zoom.doZoom = true;
        currentlyEditing.UpdateDisplay();
    }

    public void onDeleteNode()
    {
        DialogueTreeManager.tree.deleteDialogue(currentlyEditing.dd);
        currentlyEditing.UpdateDisplay();
    }
   
    public void EditTitle(string value) {
        currentlyEditing.dd.title = value;
    }
   
    public void EditLine(string value)
    {
        currentlyEditing.dd.line = value;
    }
    public void EditConnection(int id, int connID, string value)
    {
        currentlyEditing.dd.options[id].id = connID;
        currentlyEditing.dd.options[id].title = value;
    }
    public void EditConnection(int id, string value)
    {
        currentlyEditing.dd.options[id].title = value;
    }
    public void EditConnection(int id, int connID)
    {
        currentlyEditing.dd.options[id].id = connID;
    }
    public void AddConnection()
    {
        OptionData[] temp = new OptionData[currentlyEditing.dd.options.Length + 1];
        for (int i = 0; i < currentlyEditing.dd.options.Length; i++) {
            temp[i] = currentlyEditing.dd.options[i];
        }
        temp[currentlyEditing.dd.options.Length] = new OptionData();
        currentlyEditing.dd.options = temp;
    }
    public void RemoveConnection(int id)
    {
        if (id >= currentlyEditing.dd.options.Length || id < 0) { 
            return;
        }
        OptionData[] temp = new OptionData[currentlyEditing.dd.options.Length -1];
        int t = 0;
        for (int i = 0; i < currentlyEditing.dd.options.Length; i++)
        {
            if (i == id) {
                continue;
            }
            temp[t] = currentlyEditing.dd.options[i];
            t++;
        }
        currentlyEditing.dd.options = temp;
    }
    public void SwapConnection(int a, int b)
    {
        if (a >= currentlyEditing.dd.options.Length || a < 0|| b >= currentlyEditing.dd.options.Length || b < 0)
        {
            return;
        }
        OptionData temp = currentlyEditing.dd.options[b];
        currentlyEditing.dd.options[b] = currentlyEditing.dd.options[a];
        currentlyEditing.dd.options[a] = temp;
    }
}
