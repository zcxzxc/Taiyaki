using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pop : MonoBehaviour
{
    private bool popup = false;
    private TextMeshPro name;
    private TextMeshPro content;
    private TextMeshPro length;
    private Sprite_change Sc;
    private Idle_ani ia;
    void Start()
    {
        name = transform.GetChild(0).GetComponent<TextMeshPro>();
        content = transform.GetChild(1).GetComponent<TextMeshPro>();
        Sc = transform.GetChild(2).GetComponent<Sprite_change>();
        ia = transform.GetChild(2).GetComponent<Idle_ani>();
        length = transform.GetChild(4).GetComponent<TextMeshPro>();
    }

    public void Open_Pop(int identity)
    {
        if (popup)
            return;
        Sc.Identity = identity;
        Sc.change();
        List<Dictionary<string, object>> data = CSVReader.Read("taiyaki_list");
        name.text = data[identity]["Name"].ToString();
        content.text = data[identity]["Content"].ToString();
        length.text = "X "+Data_base.Taiyaki[identity].ToString();
        transform.position = new Vector3(0, 0, -4);
        ia.idle_num = (int)data[identity]["Idle"];
        transform.GetChild(2).localEulerAngles = new Vector3(0, 0, 0);
        popup = true;
    }
    void Update()
    {
        if(popup && transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0);
        }
    }

    private void OnMouseDown()
    {
        popup = false;
        transform.position = new Vector3(40, 40, 40);
        transform.localScale = new Vector3(0.2f, 0.2f, 1);
        
    }
}
