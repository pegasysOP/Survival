using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public Transform contentTransform;
    public InventoryElement itemComponentPrefab;
    
    private List<InventoryElement> itemElements = new List<InventoryElement>();

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ToggleVisibility()
    {
        if (isActiveAndEnabled)
            Hide();
        else
            Show();
    }

    public void RefreshInventory(Dictionary<string, InventoryItem> inventoryItems)
    {
        int itemCount = inventoryItems.Count;
        
        while (itemElements.Count < itemCount)
        {
            InventoryElement element = Instantiate(itemComponentPrefab, contentTransform);
            itemElements.Add(element);
        }
        
        for (int i = itemCount; i < itemElements.Count; i++)
            itemElements[i].gameObject.SetActive(false);
        
        int index = 0;
        foreach (KeyValuePair<string, InventoryItem> item in inventoryItems)
        {
            itemElements[index].gameObject.SetActive(true);
            itemElements[index].SetItem(item.Value.itemData, item.Value.quantity);
            index++;
        }
    }
}
