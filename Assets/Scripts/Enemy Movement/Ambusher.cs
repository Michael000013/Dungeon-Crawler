using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AmbusherEnemy : MonoBehaviour
{
    public float detectionRange = 6f;
    public float chargeSpeed = 12f;
    public float chargeDuration = 0.75f;
    public float cooldownTime = 1.5f;

    private Rigidbody rb;
    private Transform player;

    private bool charging;
    private float timer;
    private Vector3 chargeDirection;

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

        if (charging)
        {
            rb.MovePosition(
                rb.position + chargeDirection * chargeSpeed * Time.fixedDeltaTime
            );

            timer -= Time.fixedDeltaTime;
            if (timer <= 0f)
            {
                charging = false;
                timer = cooldownTime;
            }
            return;
        }

        timer -= Time.fixedDeltaTime;
        if (timer > 0f) return;

        float distance = Vector3.Distance(rb.position, player.position);
        if (distance <= detectionRange)
        {
            StartCharge();
        }
    }

    private void StartCharge()
    {
        chargeDirection = (player.position - rb.position).normalized;
        chargeDirection.y = 0f;

        charging = true;
        timer = chargeDuration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(3);
        }
    }
}