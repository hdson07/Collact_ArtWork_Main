﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject[] canvases;
    public Button[] buttons;

    public int current = 0;

    public Slider slider;
    public Slider slider2;

    public InputField pname;

    private float saturation;
    private int year;

    private int field;
    private string player_name;
    private CreatController CreatScript;
    private GameObject CreatedChar;

    private GameObject acc;
    void Awake()
    {
        CreatedChar = GameObject.FindGameObjectWithTag("createdChar");
        CreatScript = CreatedChar.GetComponent<CreatController>();

        canvases[0].SetActive(true);

        for (int i = 1; i < 6; i++)
            canvases[i].SetActive(false);
    }

    public void forward()
    {
        canvases[current + 1].SetActive(true);
        canvases[current].SetActive(false);
        current += 1;
        if(current == 3){
            CreatScript.creatMotion.SetTrigger("Hello");
        }
        if (current == 4)
        {
            CreatScript.createAcc(0);
            CreatScript.creatMotion.SetTrigger("Suprise");
        }
        if (current == 5)
        {
            CreatScript.creatMotion.SetTrigger("Dancing");
            StartCoroutine(stay10Seconds());
        }
    }

    IEnumerator stay10Seconds()
    {
        yield return new WaitForSeconds(10);
        canvases[current].SetActive(false);
        current = 0;
        canvases[0].SetActive(true);
        field = 1;
        saturation = (float)0.5;
        Destroy(acc);

        CreatScript.field = this.field;
        CreatScript.create(field);
        CreatScript.saturation = saturation;
        CreatScript.changeJacketColor();
        
    }

    public void backward()
    {
        canvases[current].SetActive(false);
        canvases[current - 1].SetActive(true);
        current -= 1;
    }

    public void head_color_button(int btnNum)
    {
        field = btnNum;
        CreatScript.field = this.field;
        CreatScript.create(field);
        Debug.Log(field);
    }

    public void input_name()
    {
        player_name = pname.text;
        Debug.Log(player_name);
    }
}
