using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Sprite_change Sc;
    public int cool = 0;
    private Vector3 freeze_position;
    public GameObject effect;
    public List<GameObject> list = new List<GameObject>();
    private int t = 0;

    void Start()
    {
        Sc = transform.parent.GetComponent<Sprite_change>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == collision.gameObject.layer || collision.tag == "attack")
            return;
        if (list != null&&list.FindIndex(x => x.gameObject == collision.gameObject) == -1)
            list.Add(collision.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (cool > 0)
            return;
        if (gameObject.layer == collision.gameObject.layer || collision.tag == "attack")
            return;
        //transform.parent.position = freeze_position;

        //damege(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        list.Remove(list.Find(x => x.gameObject == collision.gameObject));
    }

    private void Update()
    {
        if(cool <= 0 && list.Count > 0)
        {
            for (int i = 0; i < (Sc.multiple ? list.Count : 1); i++)
            {
               /* if(list[i].gameObject == null)
                    list.Remove(list.Find(x => x.gameObject == list[i].gameObject));
                else */
                     damege(list[i]);
            }
            cool = Sc.attack_cool;
            StartCoroutine(cool_down());

        }

    }

    private void damege(GameObject target)
    {
        if (gameObject.layer == target.layer || target == null || transform.tag == target.tag)
            return;
        target.transform.GetComponent<Sprite_change>().damege(Sc.attack);
        Instantiate(effect, target.transform.position, Quaternion.identity);
    }


    IEnumerator cool_down()
    {
        for (int i = 0; i < Sc.attack_cool; i++)
        {
            yield return new WaitForSeconds(1f);
            cool--;
        }
        cool = 0;
    }
}
