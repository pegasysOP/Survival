using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private InteractionDetector interaction;

    private Inventory inventory;
    public Inventory Inventory => inventory;

    private void Start()
    {
        inventory = new Inventory();
    }

    private void Update()
    {
        // FOR TESTING
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.iKey.wasPressedThisFrame)
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
    }
}
