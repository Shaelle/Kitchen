using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{

    public static KitchenGameManager Instance { get; private set; }


    public event EventHandler OnStateChanged;

    enum State
    {
        WaitingToStart, CountdownToStart, GamePlaying, GameOver
    }

    State state;

    float waitingToStartTimer = 1;
    float countdownToStartTimer = 3;
    float gamePlayingTimer;
    float gamePlayingTimerMax = 10;


    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }


    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GameOver:
                break;

            default:
                break;
        }

        Debug.Log(state);
    }


    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool isCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public float GetGamePlayingTimerNormalized()
    {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }

}
