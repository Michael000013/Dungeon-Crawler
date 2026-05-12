using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent Agent;
    public Transform player;
    public GameObject projectile;
    public Healthbar healthBar; // Ensure this is assigned in the Inspector

    [Header("Stats")]
    public float maxHealth = 100f;
    private float health;
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patrolling")]
    public float walkPointRange;
    public Vector3 walkPoint;
    bool walkPointSet;

    [Header("Attacking")]
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        health = maxHealth;
        Agent = GetComponent<NavMeshAgent>();
        
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;

        // Automatically find the healthbar if you forgot to drag it in
        if (healthBar == null) healthBar = GetComponentInChildren<Healthbar>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        // FIXED: Calling the exact name used in the Healthbar script
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.2f);
    }

    // --- AI Logic Methods ---
    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) Agent.SetDestination(walkPoint);
        if (Vector3.Distance(transform.position, walkPoint) < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    private void ChasePlayer() { if (player != null) Agent.SetDestination(player.position); }

    private void AttackPlayer()
    {
        Agent.SetDestination(transform.position);
        if (player != null) transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        if (!alreadyAttacked && projectile != null)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() => alreadyAttacked = false;
    private void DestroyEnemy() => Destroy(gameObject);
}