using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Sprite_change Sc;
    public int cool = 0; //붕어방 개개인의 현재 공격 쿨타임
    public GameObject effect; //공격 시 소환될 prefab
    public List<GameObject> list = new List<GameObject>(); //공격 판정 내에 있는 붕어빵들을 담을 변수
    private int t = 0;

    void Start()
    {
        Sc = transform.parent.GetComponent<Sprite_change>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //공격 콜라이더 내에 적 붕어빵이 들어올 경우 리스트에 담음 (1번만)
    {
        if (gameObject.layer == collision.gameObject.layer || collision.tag == "attack")
            return;
        if (list != null&&list.FindIndex(x => x.gameObject == collision.gameObject) == -1)
            list.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision) // 위 리스트에 담겼던 적 붕어빵이 나갈경우 리스트에서 삭제함
    {
        list.Remove(list.Find(x => x.gameObject == collision.gameObject));
    }

    private void Update() //공격 쿨타임이 0일경우 & 콜라이더 내에 적이 있을경우 공격
    {
        if(cool <= 0 && list.Count > 0)
        {
            for (int i = 0; i < (Sc.multiple ? list.Count : 1); i++)
                     damege(list[i]);

            cool = Sc.attack_cool;
            StartCoroutine(cool_down());

        }

    }

    private void damege(GameObject target) //리스트에 담긴 적 붕어빵을 공격함
    {
        if (gameObject.layer == target.layer || target == null || transform.tag == target.tag)
            return;
        target.transform.GetComponent<Sprite_change>().damege(Sc.attack);
        GameObject Obj = Instantiate(effect, target.transform.position, Quaternion.identity);
        Obj.GetComponent<Effect>().Effect_Start(0);

        Vector3 dir = target.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        switch (Sc.Identity)
        {
            case 0:
                Obj = Instantiate(effect, transform.parent.position, Quaternion.identity);
                Obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Obj.GetComponent<Effect>().Effect_Start(1);
                break;
            case 4:
                Obj = Instantiate(effect, transform.parent.position, Quaternion.identity);
                Obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Obj.GetComponent<Effect>().Effect_Start(2);
                break;
        }
        Obj = null;
    }


    IEnumerator cool_down() //1초마다 쿨타임 1씩 감소
    {
        for (int i = 0; i < Sc.attack_cool; i++)
        {
            yield return new WaitForSeconds(1f);
            cool--;
        }
        cool = 0;
    }
}
