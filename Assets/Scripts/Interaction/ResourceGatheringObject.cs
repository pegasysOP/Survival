using UnityEngine;
using System.Collections.Generic;

public class ResourceGatheringObject : InteractableObject
{
    [Header("Resource Settings")]
    [SerializeField] protected List<ResourceDrop> resourceDrops = new List<ResourceDrop>();
    [SerializeField] protected int maxHitPoints = 1;
    [SerializeField] protected bool destroyWhenDepleted = true;
    [SerializeField] protected GameObject depletedPrefab;
    
    [Header("Visual Feedback")]
    [SerializeField] protected GameObject hitEffect;
    [SerializeField] protected AudioClip hitSound;
    
    protected int currentHitPoints;
    protected AudioSource audioSource;
    
    protected virtual void Start()
    {
        currentHitPoints = maxHitPoints;
        audioSource = GetComponent<AudioSource>();
    }
    
    public override void Interact(GameObject interactor)
    {
        if (!CanInteract(interactor))
            return;
            
        OnHit(interactor);
        
        currentHitPoints--;
        
        if (currentHitPoints <= 0)
            OnDepleted(interactor);
    }
    
    protected virtual void OnHit(GameObject interactor)
    {
        PlayHitEffect();
        PlayHitSound();
        DropResources(interactor);
    }
    
    protected virtual void OnDepleted(GameObject interactor)
    {
        if (depletedPrefab != null)
            Instantiate(depletedPrefab, transform.position, transform.rotation);
        
        if (destroyWhenDepleted)
            Destroy(gameObject);
        else
            isInteractable = false;
    }
    
    protected virtual void DropResources(GameObject interactor)
    {
        foreach (ResourceDrop resourceDrop in resourceDrops)
        {
            if (resourceDrop.ShouldDrop())
                OnResourceDropped(resourceDrop.resourceType, resourceDrop.GetRandomAmount(), interactor);
        }
    }
    
    protected virtual void OnResourceDropped(ResourceType resourceType, int amount, GameObject interactor)
    {
        Debug.Log($"Dropped {amount}x {resourceType.name}");

        // TODO: add to inventory here
    }
    
    protected virtual void PlayHitEffect()
    {
        if (hitEffect != null)
            Instantiate(hitEffect, transform.position, Quaternion.identity);
    }
    
    protected virtual void PlayHitSound()
    {
        if (hitSound != null && audioSource != null)
            audioSource.PlayOneShot(hitSound);
    }
    
    public override bool CanInteract(GameObject interactor)
    {
        return base.CanInteract(interactor) && currentHitPoints > 0;
    }
}