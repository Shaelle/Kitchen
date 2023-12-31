using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{

    public static KitchenGameManager Instance { get; private set; }


    public event EventHandler OnStateChanged;

    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    enum State
    {
        WaitingToStart, CountdownToStart, GamePlaying, GameOver
    }

    State state;

    float countdownToStartTimer = 3;
    float gamePlayingTimer;
    [SerializeField, Min(1)] float gamePlayingTimerMax = 10;

    public bool isGamePaused { get; private set; } = false;


    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;

        DeliveryManager.Instance.OnRecipeSuccess += OnDelivery;
    }


    private void OnDestroy()
    {
        GameInput.Instance.OnPauseAction -= GameInput_OnPauseAction;
        GameInput.Instance.OnInteractAction -= GameInput_OnInteractAction;

        DeliveryManager.Instance.OnRecipeSuccess -= OnDelivery;
    }


    private void OnDelivery(object sender, DeliveryManager.RecipeSuccessData e)
    {
        gamePlayingTimer += e.recipe.bonusTime;

        if (gamePlayingTimer > gamePlayingTimerMax) gamePlayingTimerMax = gamePlayingTimer;
    }


    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (state == State.WaitingToStart)
        {
            state = State.CountdownToStart;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }


    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }


    private void Update()
    {

        if (isGamePaused) return;

        switch (state)
        {
            case State.WaitingToStart:
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


    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            //Time.timeScale = 0;

            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            //Time.timeScale = 1;

            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }

        
    }

}
