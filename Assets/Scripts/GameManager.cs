using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<Sprite> itemSpriteList;
    public List<PlayItem> items { get; private set; }

    public static event Action<string> OnGameOver;

    private void Start()
    {
      
        InitializeItems();
    }
    private void OnEnable() => AIController.OnBotPlayedTurn += CheckGame;
    private void OnDisable() => AIController.OnBotPlayedTurn -= CheckGame;

    private void InitializeItems()
    {
        Rock rock = new Rock(itemSpriteList[0]);
        Paper paper = new Paper(itemSpriteList[1]);
        Scissor scissor = new Scissor(itemSpriteList[2]);
        Lizard lizard = new Lizard(itemSpriteList[3]);
        Spock spock = new Spock(itemSpriteList[4]);


       items = new List<PlayItem> { rock, paper, scissor, lizard, spock };

    }
    public void CheckGame(PlayItem playerInput, PlayItem botInput)
    {
        ItemRelationshipType result = playerInput.CompareTo(botInput);
        string message = result == ItemRelationshipType.Win ? "Player Wins!" : result == ItemRelationshipType.Lose ? "Bot Wins!" : "It's a Tie!";
        OnGameOver?.Invoke(message);
    }
}
