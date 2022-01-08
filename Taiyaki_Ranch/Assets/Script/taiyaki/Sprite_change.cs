using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_change : MonoBehaviour
{
    public Sprite[] sprites;
    public int Identity;
    private SpriteRenderer SR;
    public bool list_character;
    public float Speed = 1;
    public int health = 1;
    public int attack = 1;
    public int attack_cool = 1;
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
        status_setting();
    }

    private void status_setting()
        {
        gameObject.AddComponent<BoxCollider2D>();
        if (gameObject.tag == "player")
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        List<Dictionary<string, object>> data = CSVReader.Read("taiyaki_list");
        Speed = (int)data[Identity]["DEX"];
        attack= (int)data[Identity]["ATK"];
        attack_cool = (int)data[Identity]["AGI"];
        health = (int)data[Identity]["CON"];
        transform.GetChild(0).GetComponent<BoxCollider2D>().size += new Vector2((int)data[Identity]["Range"], (int)data[Identity]["Range"]);
        
    }
    public void enemy_set()
    {
        Destroy(gameObject.GetComponent<Random_move>());

    }

    public void Destroy()
    {
        if (gameObject.tag == "enemy")
        {
            Camera.main.GetComponent<Enemy_data>().list.Remove(Camera.main.GetComponent<Enemy_data>().list.Find(x => x.gameObject == gameObject));
            Destroy(gameObject);
            if (Camera.main.GetComponent<Enemy_data>().list.Count == 0)
                Enemy_data.Be_Battle = false;
        }
        else 
        {
            Camera.main.GetComponent<Repaint>().list.Remove(Camera.main.GetComponent<Repaint>().list.Find(x => x.gameObject == gameObject));
            Destroy(gameObject);
        }
    }

    public void damege(int atk)
    {
        health -= atk;
        if (health <= 0)
            Destroy();
    }
}
