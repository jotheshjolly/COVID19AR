using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    
    public void LoadMainScene()
    {
        SceneManager.LoadScene("New Scene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("CoronaShooterScene");
    }

    public void LoadWorldScene()
    {
        SceneManager.LoadScene("MainWorldScene");
    }

    public void BackToUIScene()
    {
        SceneManager.LoadScene("ui");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    
}
