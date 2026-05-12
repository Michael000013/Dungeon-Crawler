using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float knockbackForce = 6f;
    public float attackCooldown = 1f;

    private float nextAttackTime;
    private Transform player;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    
private void FixedUpdate()
{
    if (player == null) return;

    Vector3 direction = player.position - rb.position;
    direction.y = 0f;
    direction = direction.normalized;

    rb.MovePosition(
        rb.position + direction * moveSpeed * Time.fixedDeltaTime
    );
}


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (Time.time < nextAttackTime) return;

        nextAttackTime = Time.time + attackCooldown;

        PlayerHealth health = other.GetComponentInParent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}