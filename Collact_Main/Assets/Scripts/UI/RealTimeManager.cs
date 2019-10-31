using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeManager : MonoBehaviour
{

    private CreatController CreatScript;
    private GameObject CreatedChar;
    public Slider slider1;
    public Slider slider2;
    private float saturation;
    private int year;
    void Awake()
    {
        CreatedChar = GameObject.FindGameObjectWithTag("createdChar");
        CreatScript = CreatedChar.GetComponent<CreatController>();
    }

    public void FixedUpdate()
    {
        saturation = slider1.value/100;
        year = (int)slider2.value;
        Debug.Log(saturation);
        Debug.Log(year);
        CreatScript.saturation = saturation;
        CreatScript.changeJacketColor();
        CreatScript.year = this.year;
        CreatScript.createAcc(year);
    }
}
