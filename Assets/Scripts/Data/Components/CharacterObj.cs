using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterObj : MonoBehaviour
{
    public int id;

    public TMP_Text idText;
    public TMP_InputField cname;
    public bool isNullchar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void init()
    {
        if (!isNullchar)
        {
            CharCreatorManager.inst.chars.Add(this);
            CharCreatorManager.inst.forceReload.AddListener(UpdateID);
            Character nc = new Character();
            DialogueTreeManager.tree.chars.Add(nc);
            UpdateID();
        }
    }
    public void loadChar(string s)
    {
        if (!isNullchar)
        {
            CharCreatorManager.inst.chars.Add(this);
            CharCreatorManager.inst.forceReload.AddListener(UpdateID);
            Character nc = new Character();
            nc.Name = s;
            DialogueTreeManager.tree.chars.Add(nc);
            UpdateID();
            cname.text = s;
        }
    }
    public void UpdateID()
    {
        id = CharCreatorManager.inst.chars.IndexOf(this);
        idText.text = id + "";
        Character c = DialogueTreeManager.tree.chars[id];
        c.id = id;
        DialogueTreeManager.tree.chars[id] = c;
    }
    public void UpdateCharName(string n)
    {
        Character c = DialogueTreeManager.tree.chars[id];
        c.Name = n;
        DialogueTreeManager.tree.chars[id] = c;
    }
    public void deleteElement()
    {
        CharCreatorManager.inst.chars.Remove(this);
        DialogueTreeManager.tree.chars.RemoveAt(id);
        CharCreatorManager.inst.forceReload.RemoveListener(UpdateID);
        CharCreatorManager.inst.forceReload.Invoke();
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
