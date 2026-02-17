using System;
using UnityEngine;

public class WeakSpotTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController2D>() is { } characterController2D)
        {
            characterController2D.SetPlayerExplorationState(PlayerStatus.InAdvantage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController2D>() is { } characterController2D)
        {
            characterController2D.SetPlayerExplorationState(PlayerStatus.Neutral);
        }
    }
}
