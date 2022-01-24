using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taiyaki_Manage : MonoBehaviour
{

    //소지하고 있는 붕어빵을 보여줄 스크립트임
    public GameObject Taiyaki;
    public void Inven_Render()
    {
        for(int i=0;i<28;i++)
        {
            if(Data_base.Taiyaki[i] > 0)
            {
                transform.GetChild(i).gameObject.GetComponent<Image>().enabled = true;
                transform.GetChild(i).gameObject.GetComponent<Image>().sprite = Taiyaki.GetComponent<Sprite_change>().sprites[i];
            }
            else
                transform.GetChild(i).gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
