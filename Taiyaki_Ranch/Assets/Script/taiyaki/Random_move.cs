using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_move : MonoBehaviour
{
    private bool walk = false; //이동중인가를 판단할 bool
    private Move_ani Ma;
    private Sprite_change Sc;
    IEnumerator run;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
        Sc = gameObject.GetComponent<Sprite_change>();
        Ma = gameObject.GetComponent<Move_ani>();
    }
    void Update()
    {
        run = walk_start();
        if (walk == false && Enemy_data.Be_Battle == false)
            StartCoroutine(run);
        if (Enemy_data.Be_Battle == true)
            StopCoroutine(run);
    }

    IEnumerator walk_start()
    {
        walk = true;
        
        yield return new WaitForSeconds(Random.Range(1,7));
        int move_count = Random.Range(1, 5);
        float move_x = Random.Range(-0.3f, 0.4f);
        float move_y = Random.Range(-0.3f, 0.4f);
        for (int i=0;i<move_count;i++)
        {
            Ma.Movement(move_x,move_y);
            yield return new WaitForSeconds(0.2f);
        }
        Ma.Movement(move_x, move_y);
       if(Ma.return_Idle() != 1)
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        walk = false;
    }
}
