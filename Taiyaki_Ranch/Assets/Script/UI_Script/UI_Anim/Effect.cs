using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Sprite[] sprides;
    public void Effect_Start(int Sprite)
    {
        transform.GetComponent<SpriteRenderer>().sprite = sprides[Sprite];
        StartCoroutine(fade_out());
    }
    IEnumerator fade_out()
    {
        for(int i=10;i>0;i--)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (i * 10) / 255f);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }
}
