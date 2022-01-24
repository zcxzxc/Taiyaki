using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repaint : MonoBehaviour
{
    private Vector3 vec; //랜덤 좌표를 담을 변수
    public GameObject obj; //붕어빵 Prefab
    private Vector2 Min= new Vector2(-8.69f,8.69f); //x 좌표 랜덤 범위
    private Vector2 Max = new Vector2(-1.2f, 3.2f); //y 좌표 랜덤 범위
    public List<GameObject> list = new List<GameObject>(); //필드에 그려진 플레이어 붕어빵 리스트

    private void Start()
    {
        Application.targetFrameRate = 120;
        transform.GetComponent<Save_Load_Base>().Load();
        Paint();
    }

    public void Paint() //리스트에 있는 붕어빵을 확인
    {
        Remove();
        for (int i=0;i<Data_base.Taiyaki.Length;i++)
            if (Data_base.Taiyaki[i] > 0)
                Rendering(i);
    }

    private void Remove() //필드에 있는 모든 붕어빵 삭제
    {
        for (int i = 0; i < list.Count; i++)
            Destroy(list[i].gameObject);
        list.Clear();
    }
    private void Rendering(int Identity) //리스트에 있을경우 생성
    {
        vec = new Vector3(Random.Range(Min.x, Min.y), Random.Range(Max.x, Max.y), -2);
        list.Add(Instantiate(obj, vec, Quaternion.identity));
        list[list.Count -1].GetComponent<Sprite_change>().Identity = Identity;
        list[list.Count - 1].GetComponent<Sprite_change>().change();
        list[list.Count - 1].GetComponent<Sprite_change>().status_setting();
    }
}
