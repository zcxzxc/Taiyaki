using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ani : MonoBehaviour
{
    private Sprite_change Sc;
    private bool walk_switch = false;
    // Start is called before the first frame update
    void Start()
    {
        Sc = gameObject.GetComponent<Sprite_change>();

    }
    float x;
    float y;
    public void Movement(float x,float y)
    {
        this.x = x; this.y = y;
        move_motion();
    }

    private void move_motion()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("taiyaki_list");
        int num =  (int)data[Sc.Identity]["walk"];

        switch (num)
        {
            case 0:
                horizon_move();
                break;
            case 1:
                horizon_rotation();
                if(walk_switch == true)
                    transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 15);
                else
                    transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -15);
                horizon_move();
                walk_switch = !walk_switch;
                break;
        }
    }
    private void horizon_move()
    {

        transform.position += new Vector3(x, y, 0);
        /*
        if (transform.position.x < -5.75)
            transform.position = new Vector3(-5.7f, transform.position.y, transform.position.z);
        if (transform.position.x > 5.8)
            transform.position = new Vector3(5.3f, transform.position.y, transform.position.z);
        if (transform.position.y < -4.7)
            transform.position = new Vector3(transform.position.x, -4.2f, transform.position.z);
        if (transform.position.y > 0.9)
            transform.position = new Vector3(transform.position.x,0.4f, transform.position.z);
        */
    }


    private void horizon_rotation()
    {
        if (x < 0)
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, 180, gameObject.transform.rotation.z);

        else
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, 0, gameObject.transform.rotation.z);
    }

    public int return_Idle()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("taiyaki_list");
        return (int)data[Sc.Identity]["Idle"];
    }
}
