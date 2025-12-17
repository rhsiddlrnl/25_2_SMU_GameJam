using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}