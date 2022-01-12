using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject TitlePageImage;
    public GameObject IngameHUD;
    // Start is called before the first frame update
    void Start()
    {
        TitlePageImage.SetActive(true);
        IngameHUD.SetActive(false);
        Camera.main.GetComponent<Camera>().orthographicSize=3.3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame_OnClick()
    {
        TitlePageImage.SetActive(false);
        Camera.main.GetComponent<Camera>().orthographicSize=5.4f;
        IngameHUD.SetActive(true);
    }

    public void Continue_OnClick()
    {
        TitlePageImage.SetActive(false);
        Camera.main.GetComponent<Camera>().orthographicSize=5.4f;
        IngameHUD.SetActive(true);
    }

    public void Option_OnClick()
    {

    }

    public void Exit_OnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying=false;
#else
        Application.Quit();
#endif
    }

    public void Defend_OnMouseDown()
    {
        if(Enemy_data.Be_Battle = false)
        {
            Enemy_data.Be_Battle = true;
            for(int i=0; i<5; i++)
                Camera.main.GetComponent<Enemy_data>().Rendering(1);
        }
    }
}
