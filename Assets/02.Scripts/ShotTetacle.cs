using UnityEngine;
using UnityEngine.InputSystem;

public class ShotTentacle : MonoBehaviour
{
    [SerializeField] private GameObject tentaclePrefab;

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 screenPos = new Vector3(mouseScreenPos.x, mouseScreenPos.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z));
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPos);

            Vector3 direction = (mouseWorldPos - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject tentacle = Instantiate(tentaclePrefab, transform.position, Quaternion.identity);
            tentacle.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            var tentacleMove = tentacle.GetComponent<TentacleMove>();
            {
                tentacleMove.SetDirection(direction);
            }
        }
    }
}
