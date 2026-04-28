using UnityEngine;
using UnityEngine.InputSystem;

public class player_1_movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Keyboard.current.aKey.isPressed)
        {
            movement.x = -1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            movement.x = 1f;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            movement.y = 1f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            movement.y = -1f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}