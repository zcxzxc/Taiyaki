using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject TitlePageImage; //Canvas의 타이틀 화면을 모두 비활성화 하기위한 게임오브젝트 호출

    // Start is called before the first frame update
    void Start()
    {
        TitlePageImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //NewGame_Button 클릭 이벤트
    public void OnClickNewGame()
    {
        TitlePageImage.SetActive(false);
    }

    //Continue_Button 클릭 이벤트
    public void OnClickOnContinue()
    {
        TitlePageImage.SetActive(false);
    }

    //Option_Button 클릭 이벤트
    public void OnClickOption()
    {
    }

    //Exit_Button 클릭 이벤트

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying=false;
#else
        Application.Quit();
#endif
    }
}
