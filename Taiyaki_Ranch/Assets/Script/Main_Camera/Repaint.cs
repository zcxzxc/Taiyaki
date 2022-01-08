using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repaint : MonoBehaviour
{
    private Vector3 vec;
    public GameObject obj;
    private Vector2 Min= new Vector2(-5.75f,5.8f); //x 좌표 랜덤 범위
    private Vector2 Max = new Vector2(-4.7f, 0.9f); //y 좌표 랜덤 범위
    public List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        Application.targetFrameRate = 120;
        Paint();
    }

    public void Paint()
    {
        Remove();
        for (int i=0;i<Data_base.Taiyaki.Length;i++)
            if (Data_base.Taiyaki[i] > 0)
                Rendering(i);
    }

    private void Remove()
    {
        for (int i = 0; i < list.Count; i++)
            Destroy(list[i].gameObject);
        list.Clear();
    }
    private void Rendering(int Identity)
    {
        vec = new Vector3(Random.Range(Min.x, Min.y), Random.Range(Max.x, Max.y), -2);
        list.Add(Instantiate(obj, vec, Quaternion.identity));
        list[list.Count -1].GetComponent<Sprite_change>().Identity = Identity;
        list[list.Count - 1].GetComponent<Sprite_change>().change();
    }
}
