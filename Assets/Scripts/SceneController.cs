using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{

    private void OnEnable() => UIManager.OnHideResultScreen += LoadScene;
    private void OnDisable() => UIManager.OnHideResultScreen -= LoadScene;

    private void LoadScene(Result result)
    {
       switch(result)
        {
            case Result.Win:ReloadGameScene(); break;
            case Result.Lose: LoadMenuScene(); break;
            case Result.Draw: LoadMenuScene(); break;
        }
    }

    public void ReloadGameScene()
    {
        SceneManager.LoadScene(Constants.GameSceneName);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(Constants.MenuSceneName);
    }
}
