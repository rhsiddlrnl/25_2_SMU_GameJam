using UnityEngine;
using UnityEngine.InputSystem;

public class ShotBubble : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab; // 버블 프리팹 연결

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // 마우스 위치 계산
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 screenPos = new Vector3(mouseScreenPos.x, mouseScreenPos.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z));
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPos);

            // 방향 계산
            Vector3 direction = (mouseWorldPos - transform.position).normalized;

            // 버블 생성
            GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);

            // 버블에 방향 전달 (BubbleMove 스크립트가 있다고 가정)
            var bubbleMove = bubble.GetComponent<BubbleMove>();
            {
                bubbleMove.SetDirection(direction);
            }

            SoundManager.instance.PlayAttackSound();
        }
    }
}
