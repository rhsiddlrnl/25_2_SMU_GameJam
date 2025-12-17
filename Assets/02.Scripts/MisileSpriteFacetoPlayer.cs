using UnityEngine;

public class MisileSpriteFacetoPlayer : MonoBehaviour
{
    private Transform playerTransform;

    //z축 회전 오프셋
    public float angleOffset = 0f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // 방향 벡터 구하기 (목표지점 - 내 위치)
        Vector3 direction = playerTransform.position - transform.position;

        // 각도 계산
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 회전 적용 
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}