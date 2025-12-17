using UnityEngine;

public class MisileCollision : MonoBehaviour
{
    HPControll hpController;

    [SerializeField] GameObject Shield;
    [SerializeField] float shieldLifeTime = 0.15f;   // 몇 초 후 디스폰
    [SerializeField] float shieldAngleOffset = 0f;

    void Start()
    {
        hpController = GameObject.Find("HPManager")?.GetComponent<HPControll>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            // 스폰 위치: 상대 오브젝트 위치 or 충돌 지점에 가깝게
            Vector3 spawnPos = collision.ClosestPoint(transform.position);

            // 스폰 회전: 미사일 각도 그대로(+오프셋)
            Quaternion spawnRot = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + shieldAngleOffset);

            GameObject shieldObj = Instantiate(Shield, spawnPos, spawnRot);
            Destroy(shieldObj, shieldLifeTime);

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Body"))
        {
            if (hpController != null)
                hpController.TakeDamage(1);

            Destroy(gameObject);
        }
    }
}
