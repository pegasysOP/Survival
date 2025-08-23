using UnityEngine;

public class Tree : ResourceGatheringObject
{
    protected override void Start()
    {
        base.Start();
        
        if (resourceDrops.Count == 0)
        {
            ResourceDrop woodDrop = new ResourceDrop();
            woodDrop.resourceType = new ResourceType("Wood");
            woodDrop.minAmount = 1;
            woodDrop.maxAmount = 3;
            woodDrop.dropChance = 1f;
            resourceDrops.Add(woodDrop);
        }
    }
}