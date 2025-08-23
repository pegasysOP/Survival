using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InteractionDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius = 2f;
    [SerializeField] private LayerMask interactableLayerMask = -1;
    
    private List<IInteractable> nearbyInteractables = new List<IInteractable>();
    private IInteractable currentInteractable;
    
    private void Update()
    {
        DetectInteractables();
        HandleInteractionInput();
    }
    
    private void DetectInteractables()
    {
        nearbyInteractables.Clear();
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, interactableLayerMask);
        
        foreach (Collider2D collider in colliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null && interactable.CanInteract(gameObject))
                nearbyInteractables.Add(interactable);
        }
        
        currentInteractable = GetClosestInteractable();
    }
    
    private IInteractable GetClosestInteractable()
    {
        if (nearbyInteractables.Count == 0)
            return null;
            
        IInteractable closest = null;
        float closestDistance = float.MaxValue;
        
        foreach (IInteractable interactable in nearbyInteractables)
        {
            MonoBehaviour interactableMB = interactable as MonoBehaviour;
            if (interactableMB == null)
                continue;
                
            float distance = Vector2.Distance(transform.position, interactableMB.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = interactable;
            }
        }
        
        return closest;
    }
    
    private void HandleInteractionInput()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.eKey.wasPressedThisFrame && currentInteractable != null)
            currentInteractable.Interact(gameObject);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}