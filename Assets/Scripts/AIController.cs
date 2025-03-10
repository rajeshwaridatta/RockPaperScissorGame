using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        List<PlayItem> items = GameManager.Instance.gameRules.items;
        PlayItem botInput = items[UnityEngine.Random.Range(0, items.Count)];
        OnBotPlayedTurn.Invoke(playerInput, botInput);

    }
}
