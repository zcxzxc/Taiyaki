using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_change : MonoBehaviour
{
    public Sprite[] sprites;
    public int Identity;
    private SpriteRenderer SR;
    public bool list_character;
    void Awake()
    {
        SR = this.GetComponent<SpriteRenderer>();
        //change();
    }

    public void change()
    {
        SR.sprite = sprites[0];
        SR.color = new Color(1, 1, 1);
        transform.localScale = new Vector3(1, 1, 1);
        switch (Identity)
        {
            case 0: //노멀
                break;
            case 1: //김치
                SR.color = new Color(1,103/255,103/255);
                break;
            case 2: //여물
                SR.color = new Color(0,1,0);
                break;
            case 3: //붕노
                SR.sprite = sprites[1];
                break;
            case 4: //빙빙
                break;
            case 5: //달고나
                SR.sprite = sprites[2];
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                break;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
