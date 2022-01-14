using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject t_obj;
    text_box tb;

    private void Start()
    {
        tb = t_obj.GetComponent<text_box>();
        t_obj = null;
    }
    Vector3 vec;
    private void OnMouseDown()
    {
            for (int i = 0; i < Data_base.Taiyaki.Length; i++)
                Data_base.Taiyaki[i] = 0;
            for(int i=0;i<6;i++)
                Data_base.Taiyaki[i] = 1;

                Camera.main.GetComponent<Repaint>().Paint();
        Camera.main.GetComponent<Save_Load_Base>().Save();
    }
}
