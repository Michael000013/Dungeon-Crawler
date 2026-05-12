using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 9f;

    [Header("Sprint Stamina")]
    public float maxStamina = 3f;        // seconds of sprint
    public float staminaRegenRate = 1.2f;
    public float staminaDrainRate = 1f;

    private float currentStamina;

    private Rigidbody rb;
    private Vector3 moveInput;
    private bool isSprinting;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentStamina = maxStamina;
    }

    private void Update()
    {
        // Get movement input
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(x, 0f, z).normalized;

        // Sprint input
        isSprinting = Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f;

        
    }

    private void FixedUpdate()
    {
        float speed = walkSpeed;

        if (isSprinting)
        {
            speed = sprintSpeed;
            currentStamina -= staminaDrainRate * Time.fixedDeltaTime;
        }
        else
        {
            currentStamina += staminaRegenRate * Time.fixedDeltaTime;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        rb.linearVelocity = new Vector3(
            moveInput.x * speed,
            rb.linearVelocity.y,
            moveInput.z * speed
        );
    }
}