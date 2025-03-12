using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : Singleton<PlayerScoreManager>, IScoreManager
{
    private int currentScore;
    private const string ScoreKey = Constants.Playerpref_ScoreKey;
    public static event System.Action<int> OnScoreUpdated;

    private void Start()
    {
        LoadScore();
    }
    private void LoadScore()
    {
        currentScore = PlayerPrefs.GetInt(ScoreKey, 0);
        Debug.Log("current "+ currentScore);
        OnScoreUpdated?.Invoke(currentScore);
    }
    private void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, currentScore);
        PlayerPrefs.Save();
    }
    public void AddScore()
    {
        currentScore++;
        Debug.Log("current score "+ currentScore);
        SaveScore();
        OnScoreUpdated?.Invoke(currentScore);  
    }

    public void ResetScore()
    {
        currentScore = 0;
        SaveScore();
        OnScoreUpdated?.Invoke(currentScore);  
    }

    public int GetScore()
    {
        return currentScore;
    }
    private void OnApplicationQuit()
    {
        SaveScore();
    }
}
