using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Events;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class DialogueTreeManager : MonoBehaviour
{
    public Dictionary<string, float> variables = new Dictionary<string, float>();
    public List<DialogueOBJ> dREF= new List<DialogueOBJ>();
    public List<Character> chars = new List<Character>();
    public Dictionary<DialogueOBJ,DialogueData> dialogues = new Dictionary<DialogueOBJ, DialogueData>();
    public static DialogueTreeManager tree;
    public UnityEvent refreshLines;
    public UnityEvent fullLineRefresh;
    public string folder;
    public string file;
    
    public Transform dParent;
    public GameObject dialoguePrefab;
    private bool updated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tree = this;
        
    }
    private void Start()
    {
        if (TheOnlySingletonNeeded.loaded)
        {
            loadFile(TheOnlySingletonNeeded.save);
            updated = true;
        }
        else
        {
            CharCreatorManager.inst.init();
        }

    }
    private void Update()
    {
        if (updated) {
            updated = false;
            fullLineRefresh.Invoke();
        }
    }
    public void loadFile(DialogueTreeSave dts) {

        CharCreatorManager.inst.loadChar(dts.chars);
        variables = dts.variables;
        foreach (DialogueObjSave d in dts.dialogues) {
            newDialogue(d.data,d.pos);
        }

    }
    public void newDialogue() {
        GameObject g = Instantiate(dialoguePrefab, dParent);
        
        g.GetComponent<DialogueOBJ>().Init();
        fullLineRefresh.Invoke();
    }
    public void newDialogue(DialogueData dd, float[] pos)
    {
        GameObject g = Instantiate(dialoguePrefab, dParent);
        g.transform.localPosition = new Vector3(pos[0], pos[1], pos[2]);
        g.GetComponent<DialogueOBJ>().loadData(dd);
        fullLineRefresh.Invoke();

    }

    public void deleteDialogue(DialogueData dd)
    {
        DialogueOBJ tempob = tree.dREF[dd.id];
        DialogueData temp = tree.dREF[dd.id].dd;
        updateIDsafter(dd.id, 1);
        tree.dialogues.Remove(tempob);
        tree.dREF.RemoveAt(dd.id);
        Destroy(tempob.gameObject);
        fullLineRefresh.Invoke();
    }
    public void updateIDsafter(int id,int offset) {
        for (int i = id+1; i < dialogues.Values.Count;i++) {
            tree.dialogues.Keys.ElementAt(i).dd.id -= offset;
            int t = tree.dialogues.Keys.ElementAt(i).dd.id;
            tree.dialogues[dialogues.Keys.ElementAt(i)].id = t;
            tree.dREF[i].dd.id = t;
            int c = tree.dREF[i].dd.options.Length;
            
        }
    }
    public void export() {
        try
        {
            DialogueTree export = new DialogueTree();
            export.chars = chars.ToArray();
            export.dialogues = dialogues.Values.ToArray<DialogueData>();
            export.variables = variables;
            string exp = JsonConvert.SerializeObject(export, Formatting.Indented);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(folder + "/" + file + ".wasde"))
            {
                FileStream fs = File.Create(folder + "/" + file + ".wasde");
                fs.Close();
            }
            File.WriteAllText(folder + "/" + file + ".wasde", exp);

            Application.OpenURL(folder);
        }
        catch {
            return;
        }
    }

    public void exportNoCustomExtension()
    {
        try
        {
            DialogueTree export = new DialogueTree();
            export.chars = chars.ToArray();
            export.dialogues = dialogues.Values.ToArray<DialogueData>();
            export.variables = variables;
            string exp = JsonConvert.SerializeObject(export, Formatting.Indented);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(folder + "/" + file + ".json"))
            {
                FileStream fs = File.Create(folder + "/" + file + ".json");
                fs.Close();
            }
            File.WriteAllText(folder + "/" + file + ".json", exp);

            Application.OpenURL(folder);
        }
        catch
        {
            return;
        }
    }
    public void Save()
    {
        try
        {
            DialogueTreeSave export = new DialogueTreeSave();
            export.chars = chars.ToArray();
            List<DialogueObjSave> ds = new List<DialogueObjSave>();
            foreach (DialogueOBJ v in dREF) {
                ds.Add(new DialogueObjSave(v.dd,v.gameObject.transform.localPosition));
            }
            export.dialogues = ds.ToArray();
            export.variables = variables;
            string exp = JsonConvert.SerializeObject(export, Formatting.Indented);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(folder + "/" + file + ".was"))
            {
                FileStream fs = File.Create(folder + "/" + file + ".was");
                fs.Close();
            }
            File.WriteAllText(folder + "/" + file + ".was", exp);

            Application.OpenURL(folder);
        }
        catch
        {
            return;
        }
    }
}
