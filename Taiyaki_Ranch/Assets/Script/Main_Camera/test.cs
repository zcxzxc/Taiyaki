using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool It_is_taiyaki;
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
        if (It_is_taiyaki == false)
        {
            for (int i = 0; i < Data_base.Taiyaki.Length; i++)
                Data_base.Taiyaki[i] = 0;
            for (int i = 0; i < 6; i++)
                Data_base.Taiyaki[i] = Random.Range(0, 100);

                Camera.main.GetComponent<Repaint>().Paint();
            //tb.text_open(2, 6);
        }
        else
            Destroy(gameObject);
    }
}
