using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnInteract;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Interactor>() is { } interactor)
        {
            interactor.EnableInteraction();
            interactor.InjectInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Interactor>() is { } interactor)
        {
            interactor.DisableInteraction();
            interactor.FlushInteractable();
        }
    }

    public void InvokeInteraction()
    {
        OnInteract.Invoke();
    }
}
