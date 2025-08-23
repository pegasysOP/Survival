using UnityEngine;

[System.Serializable]
public class ResourceType
{
    public string name;
    public Sprite icon;
    
    public ResourceType(string name, Sprite icon = null)
    {
        this.name = name;
        this.icon = icon;
    }
}

[System.Serializable]
public class ResourceDrop
{
    public ResourceType resourceType;
    public int minAmount = 1;
    public int maxAmount = 1;
    [Range(0f, 1f)]
    public float dropChance = 1f;
    
    public int GetRandomAmount()
    {
        return Random.Range(minAmount, maxAmount + 1);
    }
    
    public bool ShouldDrop()
    {
        return Random.value <= dropChance;
    }
}