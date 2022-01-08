using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taiyaki_touch : MonoBehaviour
{
    private pop pp;
    Sprite_change Sc;
    private void Start()
    {
        Sc = gameObject.GetComponent<Sprite_change>();
        pp = GameObject.Find("popup").GetComponent<pop>();
    }
    private void OnMouseDown()
    {
        if (gameObject.tag == "enemy")
        {
            Camera.main.GetComponent<Enemy_data>().list.Remove(Camera.main.GetComponent<Enemy_data>().list.Find(x => x.gameObject == gameObject));
            Destroy(gameObject);
        }
            
        
        else
            pp.Open_Pop(Sc.Identity);
    }
}
