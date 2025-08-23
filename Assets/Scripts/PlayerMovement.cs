using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private InteractionDetector interactionDetector;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;    
    
    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.down;
    
    private void Update()
    {
        HandleInput();
        UpdateAnimations();
    }
    
    private void HandleInput()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null)
        {
            Vector2 input = Vector2.zero;
            
            if (keyboard.wKey.isPressed)
                input.y += 1f;
            if (keyboard.sKey.isPressed)
                input.y -= 1f;
            if (keyboard.aKey.isPressed)
                input.x -= 1f;
            if (keyboard.dKey.isPressed)
                input.x += 1f;
            
            moveInput = input.normalized;
            
            // track last movement direction for idle animations
            if (moveInput != Vector2.zero)
                lastMoveDirection = moveInput;
        }
    }
    
    private void UpdateAnimations()
    {
        if (animator == null)
            return;

        animator.SetFloat("MoveX", lastMoveDirection.x);
        animator.SetFloat("MoveY", lastMoveDirection.y);
        animator.SetFloat("Speed", moveInput.magnitude);
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}