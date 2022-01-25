using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
                transform.GetChild(i).gameObject.SetActive(true);
                if(i != 0)
                     transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = Data_base.Taiyaki[i].ToString();
                transform.GetChild(i).gameObject.GetComponent<Image>().sprite = Taiyaki.GetComponent<Sprite_change>().sprites[i];
                transform.GetChild(i).gameObject.GetComponent<Taiyaki_Inven>().Identity = i;
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void Inven_OnmouseDown()
    {
        int Slot = transform.parent.GetChild(4).GetComponent<Choice_and_Change>().Choice_Slot;
        int Identity = EventSystem.current.currentSelectedGameObject.GetComponent<Taiyaki_Inven>().Identity;
        if (Slot != -1)
        {
            if(Identity != 0)
            for(int i=0;i<4;i++)
            {
                if (Data_base.Battle_Member[i] == Identity && i != Slot)
                    return;
            }

            Data_base.Battle_Member[Slot] = Identity;
            transform.parent.GetChild(1).GetComponent<Member_Image_Change>().Image_Change();
        }
    }
}
