using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    HPControll hpController;
    int enemyHp = 2;

    SpriteRenderer[] srs;
    Coroutine blinkCo;

    [System.Serializable]
    public class Loot
    {
        public string name;           // 아이템 이름 (헷갈리지 않게 메모용)
        public GameObject itemPrefab; // 아이템 프리팹
        [Range(0, 100)] public float dropChance; // 확률
    }

    public List<Loot> lootTable = new List<Loot>();

    private bool isDead = false;

    void Start()
    {
        hpController = GameObject.Find("HPManager")?.GetComponent<HPControll>();
        srs = GetComponentsInChildren<SpriteRenderer>(true);

        // �����: ��������Ʈ�� �� ã�� ��� �ٷ� Ȯ��
        // Debug.Log($"SpriteRenderers found: {srs.Length}", this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Bubble"))
        {
            enemyHp--;
            Destroy(collision.gameObject);
            if (blinkCo != null) StopCoroutine(blinkCo);
            blinkCo = StartCoroutine(BlinkByToggle());

            if (enemyHp < 1)
            {
                isDead = true;

                DropItem();
                // �״� ���� �ٷ� Destroy�ϸ� ������� ���̱� ���� ����� �� �־��.
                Destroy(gameObject, 0.15f);
            }
        }
        else
        {
            if (hpController != null) hpController.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkByToggle()
    {
        const int times = 6;
        const float interval = 0.05f;

        for (int i = 0; i < times; i++)
        {
            SetRenderersEnabled(false);
            yield return new WaitForSeconds(interval);
            SetRenderersEnabled(true);
            yield return new WaitForSeconds(interval);
        }

        SetRenderersEnabled(true);
        blinkCo = null;
    }

    void SetRenderersEnabled(bool on)
    {
        if (srs == null) return;
        for (int i = 0; i < srs.Length; i++)
        {
            if (srs[i] != null) srs[i].enabled = on;
        }
    }

    void DropItem()
    {
        foreach (Loot loot in lootTable)
        {
            // 아이템이 없으면 패스
            if (loot.itemPrefab == null) continue;

            // 주사위 굴리기 (0 ~ 100)
            float randomValue = Random.Range(0f, 100f);

            // 확률 당첨되면 생성
            if (randomValue <= loot.dropChance)
            {
                Instantiate(loot.itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
