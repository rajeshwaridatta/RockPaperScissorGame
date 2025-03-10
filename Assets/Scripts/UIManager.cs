using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class UIManager :  MonoBehaviour
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
        PlayerController.OnPlayerPlayedTurn -= UpdateUI;
        AIController.OnBotPlayedTurn -= UpdateBotUI;
    }

    private void UpdateBotUI(PlayItem playerItem, PlayItem botItem)
    {
        StartCoroutine(IUpdateBotUI(botItem));
    }
    private IEnumerator IUpdateBotUI(PlayItem botItem)
    {
        yield return new WaitForSeconds(0.5f);
        botSelection.sprite = botItem.itemSprite;
    }


    private void UpdateUI(PlayItem item)
    {
        StartCoroutine(IUpdatePlayerUI(item));
    }
    private IEnumerator IUpdatePlayerUI(PlayItem item)
    {
        yield return new WaitForSeconds(0.5f);
        playerSelection.sprite = item.itemSprite;
    }
    private void ShowResult(string obj)
    {
        StartCoroutine(ShowResultUI(obj));
    }
    private IEnumerator ShowResultUI(string obj)
    {
        yield return new WaitForSeconds(1.5f);
        resultPopup.SetActive(true);
        resultText.text = obj;
    }
   

}
