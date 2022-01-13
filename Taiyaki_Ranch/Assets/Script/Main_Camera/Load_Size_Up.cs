using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Size_Up : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = 9f;
        StartCoroutine(Size_Up());
    }
    IEnumerator Size_Up()
    {
        for(int i=0;i<6;i++)
        {
            Camera.main.orthographicSize -= 0.5f;
            yield return new WaitForSeconds(0.01f);
        }
        Camera.main.orthographicSize = 5.4f;
        Destroy(GetComponent<Load_Size_Up>());
    }
}
