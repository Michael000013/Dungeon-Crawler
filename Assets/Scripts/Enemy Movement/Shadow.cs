using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShadowEnemy : MonoBehaviour
{
    [Header("Shadow Settings")]
    public float followDelay = 2f;     // seconds behind player
    public float moveSpeed = 4f;
    public float recordInterval = 0.05f; // how often we track player

    private Rigidbody rb;
    private Transform player;

    private Queue<Vector3> positionHistory = new Queue<Vector3>();
    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        if (timer >= recordInterval)
        {
            timer = 0f;
            positionHistory.Enqueue(player.position);
        }
    }

    private void FixedUpdate()
    {
        if (positionHistory.Count == 0) return;

        // Calculate how many positions represent the delay
        int delaySteps = Mathf.RoundToInt(followDelay / recordInterval);

        if (positionHistory.Count > delaySteps)
        {
            Vector3 target = positionHistory.Dequeue();
            target.y = rb.position.y;

            Vector3 newPos = Vector3.MoveTowards(
                rb.position,
                target,
                moveSpeed * Time.fixedDeltaTime
            );

            rb.MovePosition(newPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}