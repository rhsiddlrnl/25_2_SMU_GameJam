using UnityEngine;

public class Spawner : MonoBehaviour
{
    //스폰 변수
    public GameObject missilePrefab;
    public float spawnInterval = 1f;
    private float spawnRadius = 10f;

    //난이도 조절
    public float difficultyDelay = 10f;    // 몇 초 뒤부터 어려워질지 설정 
    public float intervalDecreaseRate = 0.05f; // 1초당 줄어들 간격
    private float minSpawnInterval = 0.1f;      // 최소 간격 제한

    //회전 변수
    private float spriteRotationOffset = 0f;

    private Transform target;
    private float timer = 0f; // 미사일 생성 타이머
    private float elapsedGameTime = 0f; // 게임 총 진행 시간 타이머

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) target = player.transform;
    }

    void Update()
    {
        if (target == null) return;

        // 게임 진행 시간 누적
        elapsedGameTime += Time.deltaTime;

        // 난이도 조절
        if (elapsedGameTime >= difficultyDelay)
        {
            // 스폰 간격 감소
            spawnInterval -= intervalDecreaseRate * Time.deltaTime;

            if (spawnInterval < minSpawnInterval)
            {
                spawnInterval = minSpawnInterval;
            }
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMissile();
            timer = 0f;
        }
    }

    void SpawnMissile()
    {
        //랜덤 위치 계산
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = target.position + (Vector3)(randomDirection * spawnRadius);

        //플레이어 방향 계산 (타겟 - 생성위치)
        Vector3 direction = target.position - spawnPosition;
        //생성 
        Instantiate(missilePrefab, spawnPosition, Quaternion.identity);
    }
}
