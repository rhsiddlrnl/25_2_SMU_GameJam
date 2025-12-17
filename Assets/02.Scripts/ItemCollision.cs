using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ItemCollision : MonoBehaviour
{
    [SerializeField]
    private HPControll hpManager;

    private void Start()
    {
        hpManager = GameObject.Find("HPManager").GetComponent<HPControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {   
            hpManager.TakeHeal(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Shell"))
        {
            hpManager.TakeHeal(1);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }
}
