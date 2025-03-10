using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour,IPlayer
{
    public static event Action<PlayItem, PlayItem> OnBotPlayedTurn;
    public PlayItem ChooseItem()
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable() => PlayerController.OnPlayerPlayedTurn += PlayAITurn;
    private void OnDisable() => PlayerController.OnPlayerPlayedTurn -= PlayAITurn;

    private void PlayAITurn(PlayItem playerInput)
    {
       
        StartCoroutine(IPlayAITurn(playerInput));
    }
    private IEnumerator IPlayAITurn(PlayItem playerInput)
    {
        yield return new WaitForSeconds(0.5f);
        List<PlayItem> items = GameManager.Instance.gameRules.items;
        PlayItem botInput = items[UnityEngine.Random.Range(0, items.Count)];
        OnBotPlayedTurn.Invoke(playerInput, botInput);

    }
}
