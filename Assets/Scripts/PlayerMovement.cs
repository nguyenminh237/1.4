using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement = Vector2.zero;

        // W - đi lên
        if (Keyboard.current.wKey.isPressed)
        {
            movement.y = 1;
        }
        // S - đi xuống
        else if (Keyboard.current.sKey.isPressed)
        {
            movement.y = -1;
        }
        // A - đi trái
        else if (Keyboard.current.aKey.isPressed)
        {
            movement.x = -1;
        }
        // D - đi phải
        else if (Keyboard.current.dKey.isPressed)
        {
            movement.x = 1;
        }

        // Gửi hướng cho Animator
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);

        // Đang di chuyển hay không
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + movement * moveSpeed * Time.fixedDeltaTime
        );
    }
}