using UnityEngine;

public class MisileCollision : MonoBehaviour
{
    HPControll hpController;

    [SerializeField] GameObject Shield;
    [SerializeField] float shieldLifeTime = 0.15f;   // �� �� �� ����
    [SerializeField] float shieldAngleOffset = 0f;

    void Start()
    {
        hpController = GameObject.Find("HPManager")?.GetComponent<HPControll>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            SoundManager.instance.PlayShieldSound();
            // ���� ��ġ: ��� ������Ʈ ��ġ or �浹 ������ ������
            Vector3 spawnPos = collision.ClosestPoint(transform.position);

            // ���� ȸ��: �̻��� ���� �״��(+������)
            Quaternion spawnRot = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + shieldAngleOffset);

            GameObject shieldObj = Instantiate(Shield, spawnPos, spawnRot);
            Destroy(shieldObj, shieldLifeTime);

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Body"))
        {
            SoundManager.instance.PlayHitSound();

            if (hpController != null)
                hpController.TakeDamage(1);

            Destroy(gameObject);
        }
    }
}
