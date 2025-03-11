using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool timerActive;
    private float currentTime;
    private bool playerPlayed;
    [SerializeField] private float timeInSeconds;

    public static event Action OnTimerOver;
    public static event Action<float> OnTimerUpdated;
    private void Start()
    {
        currentTime = timeInSeconds;
        timerActive = true;
    }
    private void OnEnable()
    {
        PlayerController.OnPlayerPlayedTurn += UpdateTimer;
       
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerPlayedTurn -= UpdateTimer;
       
    }
    private void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                if(!playerPlayed)
                {
                    OnTimerOver.Invoke();
                }
            }
            else
            {
                float progress = currentTime / timeInSeconds;
                OnTimerUpdated.Invoke(timeInSeconds - currentTime);
            }
        }
        
    }
    private void UpdateTimer(PlayItem item)
    {
        playerPlayed = true;
       

    }
}
