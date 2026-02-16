using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions actions;
    private InputSystem_Actions.PlayerActions player;

    [SerializeField] private UnityEvent<InputAction.CallbackContext> OnMovePerformed;
    [SerializeField] private UnityEvent<InputAction.CallbackContext> OnInteractPerformed;
    
    
    private void Awake()
    {
        actions = new InputSystem_Actions();
        player = actions.Player;
        player.AddCallbacks(this);
    }

    private void OnDisable()
    {
        player.Disable();
    }

    private void OnEnable()
    {
        player.Enable();
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

    public void OnLook(InputAction.CallbackContext context)
    {
        LogInput(context);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        LogInput(context);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        OnInteractPerformed?.Invoke(context);
        LogInput(context);
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        LogInput(context);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        LogInput(context);
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        LogInput(context);
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        LogInput(context);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        LogInput(context);
    }
}
