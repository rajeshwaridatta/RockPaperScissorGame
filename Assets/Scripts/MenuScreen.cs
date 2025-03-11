using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button play;
    private void Start()
    {
        if (play != null)
        {
            play.onClick.RemoveAllListeners(); 
            play.onClick.AddListener(SceneController.Instance.ReloadGameScene);
        }
    }

}
