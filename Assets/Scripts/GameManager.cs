using System;
using NaughtyAttributes;
using UnityEngine;

public enum GameStates
{
    Exploration,
    Combat
}

public class GameManager : MonoBehaviour
{
    private GameStates currentState;

    private void Start()
    {
        StartGameManagerState();
    }

    [Button("Transition To Exploration")]
    public void TransitionToExplorationState()
    {
        if (currentState is GameStates.Exploration)
            return;

        currentState = GameStates.Exploration;
    }

    [Button("Transition To Combat")]
    public void TransitionToCombatState()
    {
        if (currentState is GameStates.Combat)
            return;

        currentState = GameStates.Combat;
    }

    private void ExecuteExplorationStateBehaviour()
    {
        Debug.Log("Executing Exploration State Behaviour");
    }

    private void ExecuteCombatStateBehaviour()
    {
        Debug.Log("Executing Combat State Behaviour");
    }

    private void StartGameManagerState()
    {
        currentState = GameStates.Exploration;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameStates.Exploration:
                ExecuteExplorationStateBehaviour();
                break;
            case GameStates.Combat:
                ExecuteCombatStateBehaviour();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
