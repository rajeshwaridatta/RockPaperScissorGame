using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static UnityEditor.Progress;

public class UIManager :  Singleton<UIManager>
{
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private GameObject resultPopup;
    [SerializeField] private Image playerSelection;
    [SerializeField] private Image botSelection;




    private void OnEnable()
    {
        GameManager.OnGameOver += ShowResult;
        PlayerController.OnPlayerPlayedTurn += UpdateUI;
        AIController.OnBotPlayedTurn += UpdateBotUI;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= ShowResult;
        PlayerController.OnPlayerPlayedTurn += UpdateUI;
        AIController.OnBotPlayedTurn -= UpdateBotUI;
    }

    private void UpdateBotUI(PlayItem playerItem, PlayItem botItem)
    {
        botSelection.sprite = botItem.itemSprite;
    }


    private void UpdateUI(PlayItem item)
    {
        playerSelection.sprite = item.itemSprite;
    }

    private void ShowResult(string obj)
    {
        resultPopup.SetActive(true);
        resultText.text = obj;
    }

}
