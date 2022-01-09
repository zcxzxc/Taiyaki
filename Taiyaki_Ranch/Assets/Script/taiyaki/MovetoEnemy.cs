using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovetoEnemy : MonoBehaviour
{
    Enemy_data Ed;
    private int index;
    public bool b_collision = false;
    Sprite_change Sc;
    Repaint Db;
    IEnumerator run;
    private void Start()
    {
        Sc = transform.parent.GetComponent<Sprite_change>();
        Ed = Camera.main.GetComponent<Enemy_data>();
        if (transform.parent.gameObject.tag == "enemy")
            Db = Camera.main.GetComponent<Repaint>();
    }
    public void search_shortest_enemy()
    {
        float distant = 99999;
        index = 0;
        if(transform.parent.gameObject.tag == "player")
        {
            for (int i = 0; i < Ed.list.Count; i++)
            {
                if (distant > Vector3.Distance(Ed.list[i].transform.position, gameObject.transform.parent.position))
                {
                    distant = Vector3.Distance(Ed.list[i].transform.position, gameObject.transform.parent.position);
                    index = i;
                }
            }
        }
        else if(transform.parent.gameObject.tag == "enemy")
        {
            for (int i = 0; i < Db.list.Count; i++)
            {
                if (distant > Vector3.Distance(Db.list[i].transform.position, gameObject.transform.parent.position))
                {
                    distant = Vector3.Distance(Db.list[i].transform.position, gameObject.transform.parent.position);
                    index = i;
                }
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == gameObject.tag)
            return;
        if (collision.tag == "attack")
        {
            return;
        }
        if (run != null)
            StopCoroutine(run);
        run = cool_down();
        b_collision = true;
        StartCoroutine(run);
    }
    // Update is called once per frame
    void Update()
    {
        if(Enemy_data.Be_Battle  && b_collision == false)
        {
            search_shortest_enemy();
            if (transform.parent.gameObject.tag == "enemy" && Db.list.Count > 0)
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, Db.list[index].transform.position, Sc.Speed * 0.05f);
            if (transform.parent.gameObject.tag == "player" && Ed.list.Count > 0)
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, Ed.list[index].transform.position, Sc.Speed * 0.05f);
        }
    }
    IEnumerator cool_down()
    {
            yield return new WaitForSeconds(1f);
        b_collision = false;
    }

}
