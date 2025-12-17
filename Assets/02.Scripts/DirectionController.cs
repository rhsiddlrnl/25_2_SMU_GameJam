using UnityEngine;
using UnityEngine.InputSystem;

public class DirectionController : MonoBehaviour
{
    private void Update()
    {
        if (Time.timeScale == 0) return;

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 screenPos = new Vector3(mouseScreenPos.x, mouseScreenPos.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z));
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 direction = (mouseWorldPos - transform.position).normalized;

        // 2D 기준: z축을 기준으로 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
