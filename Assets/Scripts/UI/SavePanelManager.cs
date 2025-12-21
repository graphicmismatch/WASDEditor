using UnityEngine;
using TMPro;
using System;
using System.IO;
public class SavePanelManager : MonoBehaviour
{
  
    public GameObject panel;
    public TMP_InputField folder;
    public TMP_InputField file;
    public void updateFolder(string s) {
        s = s.Replace("\\", "/");
        folder.text = s;
        DialogueTreeManager.tree.folder = s;
    }
    public void updateFile(string s) {
        s = s.Replace("\\", "/");
        file.text = s;
        DialogueTreeManager.tree.file = s;
    }
    public void loadPanel() {
        panel.SetActive(true);
        folder.text = DialogueTreeManager.tree.folder;
        if (folder.text == "") {

            DialogueTreeManager.tree.folder = Application.persistentDataPath;
            folder.text = DialogueTreeManager.tree.folder;

        }
        file.text = DialogueTreeManager.tree.file;
        if(file.text == "") {
            DialogueTreeManager.tree.file = "conversation";
            file.text = DialogueTreeManager.tree.file;
        }

    }
    public void resetpath()
    {
        DialogueTreeManager.tree.folder = Application.persistentDataPath;
        DialogueTreeManager.tree.file = "conversation";
        folder.text = DialogueTreeManager.tree.folder;
        file.text = DialogueTreeManager.tree.file;
    }
}
