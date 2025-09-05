using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElement : MonoBehaviour
{
    [Header("UI References")]
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI quantityText;

    public void SetItem(ItemData itemData, int quantity)
    {
        icon.sprite = itemData.icon;
        nameText.text = itemData.displayName;
        quantityText.text = $"x{quantity}";
    }
}
