using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private InteractionDetector interaction;

    [Header("UI")]
    [SerializeField] private InventoryPanel inventoryPanel;

    private Inventory inventory;
    public Inventory Inventory => inventory;

    private void Start()
    {
        inventory = new Inventory();
    }

    private void Update()
    {
        HandleUIInput();
    }

    private void HandleUIInput()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        // toggle inventory panel with TAB
        if (keyboard.tabKey.wasPressedThisFrame && inventoryPanel != null)
        {
            inventoryPanel.RefreshInventory(inventory.GetAllItems());
            inventoryPanel.ToggleVisibility();
        }

        // debug inventory logging with I key (keep for testing)
        if (keyboard.iKey.wasPressedThisFrame)
        {
            LogInventoryToConsole();
        }
    }

    private void LogInventoryToConsole()
    {
        Dictionary<string, InventoryItem> items = inventory.GetAllItems();
        if (items.Count == 0)
        {
            Debug.Log("=== <b><u>INVENTORY EMPTY</b></u> ===");
        }
        else
        {
            string inventoryText = "=== <b><u>INVENTORY</u></b> ===\n";
            foreach (KeyValuePair<string, InventoryItem> item in items)
            {
                inventoryText += $"- <b>{item.Value.itemData.displayName}</b>: {item.Value.quantity}\n";
            }
            inventoryText += "=================";
            Debug.Log(inventoryText);
        }
    }
}
