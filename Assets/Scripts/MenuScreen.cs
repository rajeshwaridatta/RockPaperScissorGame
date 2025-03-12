using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private TMP_Text scoreText;
    private void Start()
    {
        if (play != null)
        {
            play.onClick.RemoveAllListeners(); 
            play.onClick.AddListener(SceneController.Instance.ReloadGameScene);
        }
        ShowScore();
    }
    private void ShowScore()
    {
        scoreText.text = PlayerScoreManager.Instance.GetScore().ToString();
    }

}
