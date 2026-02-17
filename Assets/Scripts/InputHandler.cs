using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, InputSystem_Actions.IExplorationActions, InputSystem_Actions.ICombatActions
{
    private InputSystem_Actions actions;
    private InputSystem_Actions.ExplorationActions explorationInput;
    private InputSystem_Actions.CombatActions combatInput;

    [SerializeField] private UnityEvent<InputAction.CallbackContext> OnMovePerformed;
    [SerializeField] private UnityEvent<InputAction.CallbackContext> OnInteractPerformed;
    [SerializeField] private UnityEvent<InputAction.CallbackContext> OnCombatMenuNavigatePerformed;
    [SerializeField] private UnityEvent<InputAction.CallbackContext> OnCombatMenuSelectPerformed;
    [SerializeField] private UnityEvent<InputAction.CallbackContext> OnCombatMenuBackPerformed;
    
    
    
    private void Awake()
    {
        actions = new InputSystem_Actions();
        explorationInput = actions.Exploration;
        combatInput = actions.Combat;
        explorationInput.AddCallbacks(this);
        combatInput.AddCallbacks(this);

        GameManager.OnInitialStateSet += UpdateCurrentActionMap;
        GameManager.OnStateChanged += UpdateCurrentActionMap;
    }

    private void OnDestroy()
    {
        GameManager.OnInitialStateSet -= UpdateCurrentActionMap;
        GameManager.OnStateChanged -= UpdateCurrentActionMap;
    }

    private void UpdateCurrentActionMap(GameStates state)
    {
        DisableAllInputs();
        switch (state)
        {
            case GameStates.Exploration:
                explorationInput.Enable();
                break;
            case GameStates.Combat:
                combatInput.Enable();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void DisableAllInputs()
    {
        explorationInput.Disable();
        combatInput.Disable();
    }
    
    private void LogInput(InputAction.CallbackContext cxt)
    {
        Debug.Log($"Action: {cxt.action.name}, input: {cxt.control}");
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        OnMovePerformed?.Invoke(context);
        LogInput(context);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        OnInteractPerformed?.Invoke(context);
        LogInput(context);
    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        LogInput(context);
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        OnCombatMenuNavigatePerformed?.Invoke(context);
        LogInput(context);
    }

    public void OnBack(InputAction.CallbackContext context)
    {
        OnCombatMenuBackPerformed?.Invoke(context);
        LogInput(context);
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        OnCombatMenuSelectPerformed?.Invoke(context);
        LogInput(context);
    }
}
