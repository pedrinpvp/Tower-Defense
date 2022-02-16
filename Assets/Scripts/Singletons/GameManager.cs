using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Start()
    {
        UpdateGameState(GameState.WaitStartInput);
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.WaitStartInput:
                break;
            case GameState.StartWave:
                HandleStartWave();
                break;
            case GameState.OngoingWave:
                break;
            case GameState.WaitNextWave:
                break;
            case GameState.Decide:
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Lose:
                HandleDefeat();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState); //Has anybody subscribed? Invoke this function.
    }

    private void HandleDefeat()
    {
        Debug.Log("DEFEAT");
        var reiniciador = FindObjectOfType<Reiniciador>(true);
        reiniciador.gameObject.SetActive(true);
        reiniciador.AvisarDerrota();
    }

    private void HandleVictory()
    {
        Debug.Log("VICTORY");
        var reiniciador = FindObjectOfType<Reiniciador>(true);
        reiniciador.gameObject.SetActive(true);
        reiniciador.AvisarVitoria();

    }

    private void HandleStartWave()
    {
        Ondas_Adm.GetInstance().ChamarProximaWave();
    }
}


public enum GameState
{
    WaitStartInput,
    StartWave,
    OngoingWave,
    WaitNextWave,
    Decide,
    Victory,
    Lose
}