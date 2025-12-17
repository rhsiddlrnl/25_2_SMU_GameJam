using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    public float speedf = 1f;

    SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 diff = player.transform.position - transform.position;

        if (diff.x > 0.01f) sr.flipX = false;
        else if (diff.x < -0.01f) sr.flipX = true;

        Vector3 direction = diff.normalized;
        transform.position += direction * Time.deltaTime * speedf;
    }
}

