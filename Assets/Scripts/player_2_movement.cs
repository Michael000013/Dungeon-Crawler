using UnityEngine;

public class player_2_movement : MonoBehaviour
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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}