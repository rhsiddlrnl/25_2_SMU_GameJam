using System.Collections;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    HPControll hpController;
    int enemyHp = 3;

    SpriteRenderer[] srs;
    Coroutine blinkCo;

    void Start()
    {
        hpController = GameObject.Find("HPManager")?.GetComponent<HPControll>();
        srs = GetComponentsInChildren<SpriteRenderer>(true);

        // �����: ��������Ʈ�� �� ã�� ��� �ٷ� Ȯ��
        // Debug.Log($"SpriteRenderers found: {srs.Length}", this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))
        {
            enemyHp--;
            Destroy(collision.gameObject);
            if (blinkCo != null) StopCoroutine(blinkCo);
            blinkCo = StartCoroutine(BlinkByToggle());

            if (enemyHp < 1)
            {

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
}
