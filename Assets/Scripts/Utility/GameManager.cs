using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float dragtime = 0.1f;
    public static ScrollRect sr;
    public static GameManager inst;
    public bool worldSpaceMatters;
    private void Awake()
    {
        inst = this;
        sr = FindFirstObjectByType<ScrollRect>();
    }
}