using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RealTimeManager : MonoBehaviour
{

    private float saturation;
    private int year;
    private int current;
    private int field;
    public Slider slider;
    public Slider slider2;

    private CreatController CreatScript;
    private GameObject CreatedChar;

    public void Start()
    {
        CreatedChar = GameObject.FindGameObjectWithTag("createdChar");
        CreatScript = CreatedChar.GetComponent<CreatController>();
    }
    public void FixedUpdate()
    {
        saturation = (slider.value) / 100;
        year = (int)slider2.value;
        
        Debug.Log(saturation);
        Debug.Log(year);

        CreatScript.saturation = saturation;
        CreatScript.changeJacketColor();
        
        CreatScript.year = this.year;
        CreatScript.createAcc(year);

    }
}
