using UnityEngine;

public class SplitterEnemy : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;

    [Header("Splitting")]
    public GameObject splitPrefab;
    public float splitTime = 4f;
    public int splitCount = 2;
    public float spawnRadius = 1f;

    private float timer;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        dir.y = 0f;

        transform.position += dir * moveSpeed * Time.fixedDeltaTime;

        timer += Time.fixedDeltaTime;
        if (timer >= splitTime)
        {
            Split();
        }
    }

    private void Split()
    {
        if (splitPrefab == null) return;

        for (int i = 0; i < splitCount; i++)
        {
            Vector3 offset = Random.insideUnitSphere * spawnRadius;
            offset.y = 0f;

            Instantiate(splitPrefab, transform.position + offset, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}