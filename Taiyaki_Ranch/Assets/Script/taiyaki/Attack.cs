using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Sprite_change Sc;
    public int cool = 0;
    private Vector3 freeze_position;
    public GameObject effect;

    void Start()
    {
        Sc = transform.parent.GetComponent<Sprite_change>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == collision.gameObject.layer || collision.tag == "attack")
            return;
        freeze_position = transform.parent.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.layer == collision.gameObject.layer || collision.tag == "attack")
            return;
        transform.parent.position = freeze_position;
        damege(collision.gameObject);
    }

    private void damege(GameObject target)
    {
        if (cool > 0)
            return;
        if (gameObject.layer == target.layer || target == null || transform.tag == target.tag)
            return;
        cool = Sc.attack_cool;
        target.transform.GetComponent<Sprite_change>().damege(Sc.attack);
        Instantiate(effect, target.transform.position, Quaternion.identity);
        StartCoroutine(cool_down());
    }


    IEnumerator cool_down()
    {
        for(int i=0;i< Sc.attack_cool; i++)
        {
            yield return new WaitForSeconds(1f);
             cool--;
        }
        cool = 0;
    }
}
