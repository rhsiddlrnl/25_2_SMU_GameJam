using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TimerCollision : MonoBehaviour
{
    [SerializeField]
    private TimerItemControll timerManager;

    private void Start()
    {
        timerManager = GameObject.Find("TimerItemManager").GetComponent<TimerItemControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Body") || collision.gameObject.CompareTag("Shell"))
        {
            timerManager.ChangeTimerItemCount(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }
}