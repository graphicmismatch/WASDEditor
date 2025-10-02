using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class nodeDrag : MonoBehaviour
{
    public bool clicked = false;
    public float clicktime = 0.2f;
    private float clickdur = 0f;
    public RectTransform rt;
    public ButtonHold but;
    private ScrollRect sr;
    private Vector3 offset;
    public DialogueOBJ thisd;
    // Start is called before the first frame update
    void Start()
    {
        clicktime = GameManager.inst.dragtime;
        sr = GameManager.sr;
        contentScaler.updateBounds(this.rt.position, rt.sizeDelta);
    }

    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            clicked = but.buttonPressed;
            if (clicked) {
                if (GameManager.inst.worldSpaceMatters)
                {
                    offset = rt.position - Camera.main.ScreenToWorldPoint((Vector3)Mouse.current.position.value);
                }
                else
                {
                    offset = rt.position - (Vector3)Mouse.current.position.value;
                }
                sr.enabled = false;
            }
        }
        if (clicked)
        {
            if (!Mouse.current.press.isPressed)
            {
                if (clickdur < clicktime)
                {
                    EditPanelManager.inst.Load(GetComponent<DialogueOBJ>());
                }
                clicked = false;
                clickdur = 0;
                sr.enabled = true;

            }
            
            if (clickdur >= clicktime)
            {
                if (GameManager.inst.worldSpaceMatters)
                {
                    rt.position = Camera.main.ScreenToWorldPoint((Vector3)Mouse.current.position.value + offset);
                }
                else
                {
                    rt.position = (Vector3)Mouse.current.position.value + offset;
                }
                contentScaler.updateBounds(this.rt.anchoredPosition, rt.sizeDelta);
                DialogueTreeManager.tree.refreshLines.Invoke();
            }

            clickdur += Time.deltaTime;
            
           
        }
        
    }


}
