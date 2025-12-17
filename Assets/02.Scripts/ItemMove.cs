using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField]
    private bool touched = false;

    [SerializeField]
    private GameObject player;

    private Vector3 direction;
    Rigidbody2D rigid2D;

    public void SetDirection()
    {
        rigid2D.gravityScale = 0;
        touched = true;
        direction = (player.transform.position - transform.position).normalized;
    }

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (touched)
        {
            transform.position += direction * Time.deltaTime * 5f;
        }
    }
}
