using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Result
{
    Win,
    Lose,
    Draw
}
public static class Constants 
{
    public const string GameSceneName = "GameScene";
    public const string MenuSceneName = "MainMenu";
    public const string WinMessage = "Player wins!";
    public const string LoseMessage = "Player loses! ";
    public const string TieMessage = "Its a tie";
    public const string Playerpref_ScoreKey = "PlayerScore";
}
