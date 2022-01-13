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
}
