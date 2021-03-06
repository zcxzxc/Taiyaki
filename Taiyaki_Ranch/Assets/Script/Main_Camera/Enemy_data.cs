using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_data : MonoBehaviour
{
    public static bool Be_Battle = false;
    public List<GameObject> list = new List<GameObject>(); //필드에 그려진 적 붕어빵 리스트
    private Vector3 vec; //붕어빵 소환시 랜덤 좌표를 담을 변수
    public GameObject obj; //붕어빵 Prefab
    private Vector2 Min = new Vector2(-15f, 10f); //x 좌표 랜덤 범위
    private Vector2 Max = new Vector2(-5f, -6f); //y 좌표 랜덤 범위


    public void Rendering(int Identity)
    {
        vec = new Vector3(Random.Range(Min.x, Min.y), Random.Range(Max.x, Max.y), -2);
        list.Add(Instantiate(obj, vec, Quaternion.identity));
        list[list.Count - 1].GetComponent<Sprite_change>().enemy_set();
        list[list.Count - 1].GetComponent<Sprite_change>().Identity = Identity;
        list[list.Count - 1].tag = "enemy";
        list[list.Count - 1].layer = 9;
        list[list.Count - 1].transform.GetChild(0).gameObject.layer = 9;
        list[list.Count - 1].GetComponent<Sprite_change>().change();
        list[list.Count - 1].GetComponent<Sprite_change>().status_setting();
    }
}
