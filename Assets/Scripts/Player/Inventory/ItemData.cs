using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
   public string itemId;
   public string displayName;
   public Sprite icon;
    
   // Could add later: category, description, etc.
}
