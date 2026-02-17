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
    public static event Action<GameStates> OnInitialStateSet; 
    public static event Action<GameStates> OnStateChanged;

    [SerializeField] private GameEvent startCombatEvent;
    
    private GameStates currentState;
    
    private void Start()
    {
        startCombatEvent.InjectCallback(TransitionToCombatState);
        StartGameManagerState();
    }

    [Button("Transition To Exploration")]
    public void TransitionToExplorationState()
    {
        if (currentState is GameStates.Exploration)
            return;

        currentState = GameStates.Exploration;
        OnStateChanged?.Invoke(currentState);
        Debug.Log("Executing Exploration State Behaviour");

    }

    [Button("Transition To Combat")]
    public void TransitionToCombatState()
    {
        if (currentState is GameStates.Combat)
            return;

        currentState = GameStates.Combat;
        OnStateChanged?.Invoke(currentState);
        Debug.Log("Executing Combat State Behaviour");
    }

    private void ExecuteExplorationStateBehaviour()
    {
    }

    private void ExecuteCombatStateBehaviour()
    {
    }

    private void StartGameManagerState()
    {
        currentState = GameStates.Exploration;
        OnInitialStateSet?.Invoke(currentState);
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
