using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public List<Sprite> itemSpriteList;
    public GameRules gameRules;
    public static event Action<string> OnGameOver;
    private void Start()
    {
        gameRules = new GameRules();
        InitializeItems();
    }
    private void OnEnable() => AIController.OnBotPlayedTurn += CheckGame;
    private void OnDisable() => AIController.OnBotPlayedTurn -= CheckGame;

    private void InitializeItems()
    {
        Rock rock = new Rock(itemSpriteList[0]);
        Paper paper = new Paper(itemSpriteList[1]);
        Scissor scissor = new Scissor(itemSpriteList[2]);

        rock.AddBehaviour(scissor, ItemRelationshipType.Pass);
        rock.AddBehaviour(paper, ItemRelationshipType.Fail);


        paper.AddBehaviour(scissor, ItemRelationshipType.Fail);
        paper.AddBehaviour(paper, ItemRelationshipType.Pass);


        scissor.AddBehaviour(paper, ItemRelationshipType.Pass);
        scissor.AddBehaviour(rock, ItemRelationshipType.Fail);

        gameRules.AddItem(rock);
        gameRules.AddItem(paper);
        gameRules.AddItem(scissor);

    }
    public void CheckGame(PlayItem playerInput, PlayItem botInput)
    {
        ItemRelationshipType result = playerInput.CompareTo(botInput);
        string message = result == ItemRelationshipType.Pass ? "Player Wins!" : result == ItemRelationshipType.Fail  ? "Bot Wins!" : "It's a Tie!";
        OnGameOver?.Invoke(message);
    }
}
