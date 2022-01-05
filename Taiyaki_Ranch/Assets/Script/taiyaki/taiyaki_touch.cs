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
        pp.Open_Pop(Sc.Identity);
    }
}
