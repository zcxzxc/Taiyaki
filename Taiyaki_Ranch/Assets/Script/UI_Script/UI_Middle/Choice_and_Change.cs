using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_and_Change : MonoBehaviour
{
    //멤버가 지닌 버튼과 연결된 스크립트임 각각의 슬롯 넘버도 있음
    public int Choice_Slot = -1;
    // Update is called once per frame
    public void Choice_Member_Slot(int Slot)
    {
        Choice_Slot = Slot;
        if (Choice_Slot != -1)
            transform.position = transform.parent.GetChild(1).GetChild(Choice_Slot).position;
        else
            gameObject.transform.position = new Vector3(1500, 1500, 0);
    }
    public void Reset_Slot()
    {
        Choice_Member_Slot(-1);
    }
}
