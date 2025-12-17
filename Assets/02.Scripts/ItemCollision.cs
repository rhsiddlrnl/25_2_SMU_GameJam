using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ItemCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Shell"))
        {
            Destroy(gameObject);
        }
    }
}
