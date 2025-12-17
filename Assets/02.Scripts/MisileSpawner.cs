using UnityEngine;

public class MisileSpawner : MonoBehaviour
{
    public GameObject missilePrefab;
    public float spawnInterval = 0.5f;
    public float spawnRadius = 10f;

    // ★ 여기에 90, -90 등을 넣어서 그림 방향을 맞추세요!
    public float spriteRotationOffset = 0f;

    private Transform target;
    private float timer = 0f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) target = player.transform;
    }

    void Update()
    {
        if (target == null) return;
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMissile();
            timer = 0f;
        }
    }

    void SpawnMissile()
    {
        // 1. 랜덤 위치 계산
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = target.position + (Vector3)(randomDirection * spawnRadius);

        Instantiate(missilePrefab, spawnPosition, Quaternion.identity);
    }
}
