using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject IngameHUD;
    // Start is called before the first frame update

    public void Defend_OnMouseDown()
    {
        if(Enemy_data.Be_Battle == false)
        {
            Enemy_data.Be_Battle = true;
            for(int i=0; i<5; i++)
                Camera.main.GetComponent<Enemy_data>().Rendering(1);
        }
    }

    public void Control_OnMouseDown()
    {
        IngameHUD.transform.GetChild(0).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(1500, -70);
        IngameHUD.transform.GetChild(1).gameObject.SetActive(true);
        IngameHUD.transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<Taiyaki_Manage>().Inven_Render();
        IngameHUD.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<Member_Image_Change>().Image_Change();
        IngameHUD.transform.GetChild(2).transform.position = new Vector3(1500, 2000, 0);
    }

    public void Contriol_Exit()
    {
        IngameHUD.transform.GetChild(0).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(760, -70);
        IngameHUD.transform.GetChild(1).gameObject.SetActive(false);
        IngameHUD.transform.GetChild(2).transform.position = new Vector3(960, 540, 0);
    }
}
