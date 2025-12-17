using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TentacleCollision : MonoBehaviour
{
    private GameObject player;

    private TentacleMove tentacleMove;

    [SerializeField]
    bool touched = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        tentacleMove = GetComponent<TentacleMove>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            // Rigidbody2D의 gravityScale을 0으로 설정하고, velocity도 0으로 초기화
            Rigidbody2D itemRb = collision.GetComponent<Rigidbody2D>();
            if (itemRb != null)
            {
                itemRb.gravityScale = 0f;
                itemRb.linearVelocity = Vector2.zero;
            }

            // 아이템을 촉수에 붙임
            collision.transform.SetParent(this.transform);

            Vector3 direction = (player.transform.position - transform.position).normalized;
            tentacleMove.SetDirection(direction);
            touched = true;
        }
        else if (collision.gameObject.CompareTag("Bound"))
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            tentacleMove.SetDirection(direction);
            touched = true;
        }
        else if (collision.gameObject.CompareTag("Body") && touched)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Shell") && touched)
        {
            Destroy(gameObject);
        }
    }
}
