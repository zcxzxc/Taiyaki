using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Sprite_change Sc;
    MovetoEnemy MtE;
    public int cool = 0;
    private GameObject obj;
    private Vector3 freeze_position;

    void Start()
    {
        Sc = GetComponent<Sprite_change>();
        MtE = GetComponent<MovetoEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        freeze_position = transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.position = freeze_position;
        damege(collision.gameObject);
    }

    private void damege(GameObject target)
    {
        if (cool > 0)
            return;
        cool = Sc.attack_cool;
        target.GetComponent<Sprite_change>().damege(Sc.attack);
        StartCoroutine(cool_down());
    }


    IEnumerator cool_down()
    {
        for(int i=0;i<cool + 2;i++)
        {
            yield return new WaitForSeconds(1f);
             cool--;
        }
        
    }
}
