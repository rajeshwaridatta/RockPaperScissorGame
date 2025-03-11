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
    [SerializeField] private Slider timerFg;
    private Result gameResult;

    public static event Action<Result> OnHideResultScreen;

   
    private void OnEnable()
    {
        GameManager.OnGameOver += ShowResult;
        PlayerController.OnPlayerPlayedTurn += UpdateUI;
        AIController.OnBotPlayedTurn += UpdateBotUI;
        Timer.OnTimerUpdated += UpdateTimer;
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
    private void ShowResult(Result result)
    {
        StartCoroutine(ShowResultUI(result));
    }
    private IEnumerator ShowResultUI(Result result)
    {
        yield return new WaitForSeconds(0.5f);
        gameResult = result;
        resultPopup.SetActive(true);
        string message = result == Result.Win ? Constants.WinMessage : result == Result.Lose ? Constants.LoseMessage : Constants.TieMessage;
        resultText.text = message;
        StartCoroutine(HideResultUI());
    }
    private IEnumerator HideResultUI()
    {
        yield return new WaitForSeconds(0.8f);
        resultPopup.SetActive(false);
        OnHideResultScreen.Invoke(gameResult);
    }
    private void UpdateTimer(float diff)
    {
         timerFg.value = Mathf.Lerp(1, 0,diff);
    }


}
