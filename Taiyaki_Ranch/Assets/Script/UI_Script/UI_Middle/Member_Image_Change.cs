using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Member_Image_Change : MonoBehaviour
{
    //관리 시 4마리의 UI붕어빵의 이미지 변환임
    public GameObject Taiyaki;
    public void Image_Change()
    {
        for(int i=0;i<4;i++)
        {
            if (Data_base.Battle_Member[i] >= 0)
            {
                transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
                transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = Taiyaki.GetComponent<Sprite_change>().sprites[Data_base.Battle_Member[i]];
            }
            else
                transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }
    }

}
