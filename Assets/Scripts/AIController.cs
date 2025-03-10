using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour
{
    public static event Action<PlayItem, PlayItem> OnBotPlayedTurn;
   

    private void OnEnable() => PlayerController.OnPlayerPlayedTurn += PlayAITurn;
    private void OnDisable() => PlayerController.OnPlayerPlayedTurn -= PlayAITurn;

    // Custom testing. set to false for production.
    private readonly bool fixed_test_input = false;
    private readonly int fixed_test_index = 4;

    private void PlayAITurn(PlayItem playerInput)
    {
       
        StartCoroutine(IPlayAITurn(playerInput));
    }
    private IEnumerator IPlayAITurn(PlayItem playerInput)
    {
        yield return new WaitForSeconds(0.5f);
        List<PlayItem> items = GameManager.Instance.items;
        PlayItem botInput = items[fixed_test_input ? fixed_test_index : UnityEngine.Random.Range(0, items.Count)];
        OnBotPlayedTurn.Invoke(playerInput, botInput);

    }
}
