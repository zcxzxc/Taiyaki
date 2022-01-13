using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Manager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }
    public void Continue()
    {
        SceneManager.LoadScene("Main_Scene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
