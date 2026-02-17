using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Objects/GameEvent")]
public class GameEvent : ScriptableObject
{
    private Action action;

    public void InvokeAction()
    {
        action?.Invoke();
    }

    public void InjectCallback(Action callback)
    {
        action += callback;
    }
}
