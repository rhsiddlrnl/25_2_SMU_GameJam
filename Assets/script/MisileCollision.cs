using UnityEngine;

public class MisileCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 적일 때만 파괴 등 처리 가능
        Destroy(gameObject);
    }
}
