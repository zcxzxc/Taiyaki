using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class text_box : MonoBehaviour
{
    private bool open = false;
    private int line_1;
    private int line_2;
    TextMeshPro name;
    TextMeshPro content;
    SpriteRenderer SR;
    private float speed = 3;
    public Sprite[] sprites;

    private void Start()
    {
        SR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        name = transform.GetChild(2).GetComponent<TextMeshPro>();
        content = transform.GetChild(3).GetComponent<TextMeshPro>();
    }
    public void text_open(int line_1,int line_2)
    {
        this.line_1 = line_1 -2;
        this.line_2 = line_2 -2;
        write();
        open = true;
    }

    private void Update()
    {
        if(open)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,-4.7f,-5), speed);
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -19.5f, -5), speed);
    }

    private void write()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("text");
        name.text = data[line_1]["Name"].ToString();
        draw_face(name.text);
        content.text = data[line_1]["Content"].ToString();
    }

    private void OnMouseDown()
    {
        if(open)
        {
            line_1++;
            if(line_1 > line_2)
            {
                open = false;
                return;
            }
            write();
        }
    }

    private void draw_face(string name)
    {
        SR.sprite = sprites[0];
        if (name.Equals("빵붕어"))
            SR.sprite = sprites[1];
    }
}
