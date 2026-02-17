using NaughtyAttributes;
using UnityEngine;

public enum PlayerStatus
{
    Neutral,
    InDanger,
    InAdvantage
}

[CreateAssetMenu(fileName = "PlayerExplorationStateData", menuName = "Scriptable Objects/PlayerExplorationStateData")]
public class PlayerExplorationStateData : ScriptableObject
{
    [SerializeField, ReadOnly] private PlayerStatus currentPlayerStatus;

    public void SetPlayerStatus(PlayerStatus newValue)
    {
        currentPlayerStatus = newValue;
        Debug.Log($"Player is in {currentPlayerStatus} state while Exploring");
    }
}
