using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Size_Up : MonoBehaviour
{
    private Image TitlePage_BackGroundImage;

    public GameObject InGameHUD_Top;
    public GameObject InGaneHUD_Bottom;
    
    public GameObject Cloud_Right;
    public GameObject Cloud_Left;
    private RectTransform rectTransform_right;
    private RectTransform rectTransform_left;

    public float frame_time;

    // Start is called before the first frame update
    void Start()
    {
        if(Cloud_Right != null && Cloud_Left != null)
        {
            rectTransform_left = Cloud_Left.GetComponent<RectTransform>();
            rectTransform_right = Cloud_Right.GetComponent<RectTransform>();
        }
        TitlePage_BackGroundImage = transform.GetChild(1).GetComponent<Image>();
        TitlePage_BackGroundImage.color = new Color(0, 0, 0, 200/255f);
        Camera.main.orthographicSize = 3.3f;
        StartCoroutine(Size_Up());
    }
    IEnumerator Size_Up()
    {
        float fadeCount = 200/255f;
        for(int i=0;i<frame_time;i++)
        {
            fadeCount-=200/frame_time;

            rectTransform_right.anchoredPosition = new Vector3(960/frame_time*(i+1)-960, 0, 0);
            rectTransform_left.anchoredPosition = new Vector3(960-960/frame_time*(i+1), 0, 0);

            TitlePage_BackGroundImage.color = new Color(0,0,0, fadeCount);
            Camera.main.orthographicSize += (5.4f-3.3f)/frame_time;
            yield return new WaitForSeconds(0.01f);
        }
        Camera.main.orthographicSize = 5.4f;
        Destroy(Cloud_Right);
        Destroy(Cloud_Left);
        Destroy(transform.GetChild(1).gameObject);
        Destroy(GetComponent<Load_Size_Up>());
    }
}
