using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }
}