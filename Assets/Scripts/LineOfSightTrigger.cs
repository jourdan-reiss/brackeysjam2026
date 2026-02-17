using UnityEngine;

public class LineOfSightTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController2D>() is { } characterController2D)
        {
            characterController2D.SetPlayerExplorationState(PlayerStatus.InDanger);
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
