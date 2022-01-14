using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_ani : MonoBehaviour
{
    Sprite_change Sc;
    public int idle_num; //스탠딩 모션 번호를 csv에서 끌어옴
    void Start()
    {
        Sc = gameObject.GetComponent<Sprite_change>();
        List<Dictionary<string, object>> data = CSVReader.Read("taiyaki_list");
        idle_num = (int)data[Sc.Identity]["Idle"];
        if (idle_num == 0 && Sc.list_character == false)
            Destroy(GetComponent<Idle_ani>());
    }
    // Update is called once per frame
    void Update()
    {
        
        animation();
    }

    private void animation()
    {
        switch(idle_num)
        {
            case 1:
                transform.localEulerAngles += new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 2);
                break;
        }
    }
}
