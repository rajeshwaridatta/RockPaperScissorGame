using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameRule gameRule;
    [SerializeField] private List<Sprite> itemSpriteList;
    private Result gameResult;
    public List<PlayItem> items { get; private set; }

    public static event Action<Result> OnGameOver;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
      
        InitializeItems();
    }
    private void OnEnable()
    {
        AIController.OnBotPlayedTurn += CheckGame;
        Timer.OnTimerOver += GameOver;
    }
    private void OnDisable()
    {
        AIController.OnBotPlayedTurn -= CheckGame;
        Timer.OnTimerOver -= GameOver;
    }

    private void InitializeItems()
    {
        PlayItem.GameRuleData = gameRule;
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
        gameResult = result == ItemRelationshipType.Win ? Result.Win : result == ItemRelationshipType.Lose ? Result.Lose : Result.Draw;
        OnGameOver?.Invoke(gameResult);
    }
    public void GameOver()
    {
        OnGameOver?.Invoke(Result.Lose);
    }
}
