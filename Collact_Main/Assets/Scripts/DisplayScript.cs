using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera[] MultiDisplay = new Camera[2];
    void Start()
    {
         Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate(834,1194,30);
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
        mapCameraToDisplay();
    }

    void mapCameraToDisplay()
{
    //Loop over Connected Displays
    for (int i = 0; i < Display.displays.Length; i++)
    {
        MultiDisplay[i].targetDisplay = i; //Set the Display in which to render the camera to
        Display.displays[i].Activate(); //Enable the display
    }
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
