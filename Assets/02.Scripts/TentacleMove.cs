using UnityEngine;

public class TentacleMove : MonoBehaviour
{
    Vector3 direction;
    void Update()
    {
        transform.position += direction * Time.deltaTime * 5f;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
