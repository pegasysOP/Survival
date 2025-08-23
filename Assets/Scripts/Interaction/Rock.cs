using UnityEngine;

public class Rock : ResourceGatheringObject
{
    protected override void Start()
    {
        base.Start();
        
        if (resourceDrops.Count == 0)
        {
            ResourceDrop stoneDrop = new ResourceDrop();
            stoneDrop.resourceType = new ResourceType("Stone");
            stoneDrop.minAmount = 1;
            stoneDrop.maxAmount = 2;
            stoneDrop.dropChance = 1f;
            resourceDrops.Add(stoneDrop);
        }
    }
}