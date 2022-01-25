using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member_Button : MonoBehaviour
{
    //멤버 터치시 장착 슬롯이 변경될 스크립트임
    public int Slot;
    public void Slot_Change_Button()
    {
        transform.parent.parent.GetChild(4).GetComponent<Choice_and_Change>().Choice_Member_Slot(Slot);
    }
}
