using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class CharacterController2D : MonoBehaviour
{
    private Interactor interactor;

    private void Awake()
    {
        interactor = GetComponent<Interactor>();
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        Debug.Log("Move Player Requested.");
        Move(context.ReadValue<Vector2>());
    }

    public void PerformInteract()
    {
        Debug.Log("Performing Interaction");
        interactor.PerformInteraction();
    }

    private void Move(Vector2 direction)
    {
        Debug.Log($"Move player in direction {direction}");
        transform.Translate(direction);
    }
}
