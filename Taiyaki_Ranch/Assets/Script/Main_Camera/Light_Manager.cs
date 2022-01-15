using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Manager : MonoBehaviour
{
    public GameObject global_light;
    public GameObject cendle;
    void Start()
    {
        bool PM = false;
        if (DateTime.Now.ToString(("tt")) == "PM")
            PM = true;

        Light_Set(Int32.Parse(DateTime.Now.ToString(("hh"))), PM);
    }
    private void Light_Set(int time,bool PM)
    {
        if (PM == false && time >= 7)
            turn_off();

        else if (PM == true && time <= 6 || time == 12)
            turn_off();

        else
            global_light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0.2f;
        cendle.SetActive(true);
    }

    private void turn_off()
    {
        global_light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 1;
        cendle.SetActive(false);
    }
}
