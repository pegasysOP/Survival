using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    /// <summary>
    /// All items currently in the inventory (Item ID : InventoryItem with quantity etc.)
    /// </summary>
    private Dictionary<string, InventoryItem> items = new Dictionary<string, InventoryItem>();

    public bool AddItem(InventoryItem inventoryItem)
    {
        if (inventoryItem == null || inventoryItem.itemData == null || inventoryItem.quantity <= 0)
            return false;

        return AddItem(inventoryItem.itemData, inventoryItem.quantity);
    }

    public bool AddItem(ItemData itemData, int quantity = 1)
    {
        if (itemData == null || quantity <= 0)
            return false;

        if (items.ContainsKey(itemData.itemId))
            items[itemData.itemId].quantity += quantity;
        else
            items[itemData.itemId] = new InventoryItem { itemData = itemData, quantity = quantity };

        Debug.Log($"Added <b>{quantity} x {itemData.itemId}</b> to inventory.");

        return true;
    }

    public bool RemoveItem(ItemData itemData, int quantity = 1)
    {
        if (itemData == null)
            return false;

        return RemoveItem(itemData.itemId, quantity);
    }

    public bool RemoveItem(string itemId, int quantity = 1)
    {
        if (!items.ContainsKey(itemId) || quantity <= 0)
            return false;

        if (items[itemId].quantity < quantity)
            return false;

        items[itemId].quantity -= quantity;
        if (items[itemId].quantity == 0)
            items.Remove(itemId);

        Debug.Log($"Removed <b>{quantity} x {itemId}</b> from inventory.");

        return true;
    }

    public bool HasItem(ItemData itemData, int quantity = 1)
    {
        if (itemData == null)
            return false;

        return HasItem(itemData.itemId, quantity);
    }

    public bool HasItem(string itemId, int quantity = 1)
    {
        return items.ContainsKey(itemId) && items[itemId].quantity >= quantity;
    }

    public int GetQuantity(ItemData itemData)
    {
        if (itemData == null)
            return 0;

        return GetQuantity(itemData.itemId);
    }

    public int GetQuantity(string itemId)
    {
        return items.ContainsKey(itemId) ? items[itemId].quantity : 0;
    }

    public Dictionary<string, InventoryItem> GetAllItems()
    {
        return new Dictionary<string, InventoryItem>(items);
    }
}
