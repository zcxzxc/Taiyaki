using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Size_Up : MonoBehaviour
{
    private Image TitlePage_BackGroundImage;

    public GameObject InGameHUD_Top;
    public GameObject InGaneHUD_Bottom;

    Vector3 vectors;

    // Start is called before the first frame update
    void Start()
    {
        TitlePage_BackGroundImage = transform.GetChild(1).GetComponent<Image>();
        TitlePage_BackGroundImage.color = new Color(0, 0, 0, 200/255f);
        Camera.main.orthographicSize = 3.3f;
        StartCoroutine(Size_Up());
    }
    IEnumerator Size_Up()
    {
        float fadeCount = 0.5f;
        for(int i=0;i<40;i++)
        {
            fadeCount-=0.12f;
            TitlePage_BackGroundImage.color = new Color(0,0,0, fadeCount);
            Camera.main.orthographicSize += 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        Camera.main.orthographicSize = 5.4f;
        Destroy(transform.GetChild(1).gameObject);
        Destroy(GetComponent<Load_Size_Up>());
    }
}
