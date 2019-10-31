using System.Collections;
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

    private int field;
    private float saturation;
    private int year;
    private string player_name;
    private CreatController CreatScript;
    private GameObject CreatedChar;

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
        if (current == 4)
        {
            saturation = (slider.value) / 100;

            //we have to embeded this part to changing saturation realtime
            CreatScript.saturation = saturation;
            CreatScript.changeJacketColor();
            //
 
            

        }
        if (current == 5)
        {
            year = (int)slider2.value;
            StartCoroutine(stay10Seconds());
        }
    }

    IEnumerator stay10Seconds()
    {
        yield return new WaitForSeconds(10);
        canvases[current].SetActive(false);
        current = 0;
        canvases[0].SetActive(true);
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
