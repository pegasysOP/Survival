using UnityEngine;

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
}
