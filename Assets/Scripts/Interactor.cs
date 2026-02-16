using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Interactable objectToInteractWith;
    private bool canInteract;
    
    
    public void EnableInteraction()
    {
        Debug.Log("Can perform interactions");
        canInteract = true;
    }

    public void DisableInteraction()
    {
        Debug.Log("Can not perform interactions");
        canInteract = false;
    }

    public void InjectInteractable(Interactable interactable)
    {
        objectToInteractWith = interactable;
    }

    public void PerformInteraction()
    {
        if (!canInteract)
        {
            Debug.Log("Could not perform this interaction");
            return;
        }

        objectToInteractWith.InvokeInteraction();
    }

    public void FlushInteractable()
    {
        objectToInteractWith = null;
    }
}
