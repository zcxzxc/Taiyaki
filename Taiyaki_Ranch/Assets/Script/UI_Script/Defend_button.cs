using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend_button : MonoBehaviour
{
    public void button_down()
    {
        if (Enemy_data.Be_Battle == false)
        {

            Enemy_data.Be_Battle = true;
            for (int i = 0; i < 5; i++)
                Camera.main.GetComponent<Enemy_data>().Rendering(1);
        }
    }
}
