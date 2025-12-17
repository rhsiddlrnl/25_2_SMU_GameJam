using UnityEngine;

public class MisileCollision : MonoBehaviour
{
    HPControll hpController;

    private void Start()
    {
        hpController = GameObject.Find("HPManager").GetComponent<HPControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Body"))
        {
            hpController.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
