using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    HPControll hpController;

    private void Start()
    {
        hpController = GameObject.Find("HPManager").GetComponent<HPControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Destroy(gameObject);
        }
        else
        {
            hpController.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
