using UnityEngine;

public class OrbitingBoss : MonoBehaviour
{
    [Header("Orbit Settings")]
    public float orbitRadius = 4f;
    public float orbitSpeed = 2f;
    public float moveSpeed = 6f;

    private Transform player;
    private Rigidbody rb;
    private float orbitAngle;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        orbitAngle += orbitSpeed * Time.fixedDeltaTime;

        Vector3 offset = new Vector3(
            Mathf.Cos(orbitAngle),
            0f,
            Mathf.Sin(orbitAngle)
        ) * orbitRadius;

        Vector3 targetPosition = player.position + offset;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}