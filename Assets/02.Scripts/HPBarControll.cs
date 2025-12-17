using UnityEngine;
using UnityEngine.UI;

public class HPBarControll : MonoBehaviour
{
    [SerializeField]
    private Image hpImage;
    [SerializeField]
    private GameObject hpBar;

    public void SetHPBar(int HP)
    {
        Vector2 heartPos = new Vector2(0, 0);

        for (int i = 0; i < HP; i++)
        {
            // hpBarImage를 hpBarObject의 자식으로 생성
            Image newHpBar = Instantiate(hpImage, hpBar.transform);

            // 위치 지정 (예: 가로로 나열)
            RectTransform rt = newHpBar.GetComponent<RectTransform>();
            rt.anchoredPosition = heartPos;

            // 다음 하트 위치 조정 (예: 30픽셀씩 오른쪽으로 이동)
            heartPos.x += 50f;
        }
    }
    
    public void ClearHPBar()
    {
        foreach (Transform child in hpBar.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
