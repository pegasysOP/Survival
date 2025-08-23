using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] protected bool isInteractable = true;
    
    public virtual bool CanInteract(GameObject interactor)
    {
        return isInteractable;
    }
    
    public abstract void Interact(GameObject interactor);
}