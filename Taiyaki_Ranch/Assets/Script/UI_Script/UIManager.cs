using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Defend_OnMouseDown()
    {
        if(Enemy_data.Be_Battle = false)
        {
            Enemy_data.Be_Battle = true;
            for(int i=0; i<5; i++)
                Camera.main.GetComponent<Enemy_data>().Rendering(1);
        }
    }
}
