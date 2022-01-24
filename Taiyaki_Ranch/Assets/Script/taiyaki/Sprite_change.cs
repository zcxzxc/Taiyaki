using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_change : MonoBehaviour
{
    public Sprite[] sprites;
    public int Identity; //붕어빵의 개체값
    private SpriteRenderer SR;
    public bool list_character;
    public float Speed = 1; //적에게 다가갈때 이동속도
    public int health = 1; //체력
    public int attack = 1; //공격력
    public int attack_cool = 1; //공격 속도
    public bool multiple = false; //다중공격 여부
    void Awake()
    {
        SR = this.GetComponent<SpriteRenderer>();
        //change();
    }

    public void change() //개체값을 전달받아서 스프라이트 이미지를 바꿈
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

   public void status_setting() //개체값에 따라 csv에 적혀있는 스텟을 끌어옴
        {
        gameObject.AddComponent<BoxCollider2D>();
        if (gameObject.tag == "enemy")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(GetComponent<taiyaki_touch>());
        }
        List<Dictionary<string, object>> data = CSVReader.Read("taiyaki_list");
        Speed = (int)data[Identity]["DEX"];
        attack= (int)data[Identity]["ATK"];
        attack_cool = (int)data[Identity]["AGI"];
        health = (int)data[Identity]["CON"];
        if ((int)data[Identity]["Multiple"] == 1)
            multiple = true;
        transform.GetChild(0).GetComponent<CircleCollider2D>().radius += (int)data[Identity]["Range"];
        
    }
    public void enemy_set() //적은 랜덤으로 움직이지 않고 다가가기만 함
    {
        Destroy(gameObject.GetComponent<Random_move>());

    }

    public void Destroy() //체력이 0이 되거나 필요로 의해 붕어빵 오브젝트를 지워야 할때, 리스트에서 삭제 후 오브젝트를 삭제함
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
