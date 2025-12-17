using UnityEngine;
using UnityEngine.UI;

public class TimerItemBarControll : MonoBehaviour
{
    [SerializeField]
    private Image timerImage;
    [SerializeField]
    private GameObject timerBar;

    public void SetTimerBar(int Count)
    {
        Vector2 timerPos = new Vector2(0, 0);

        for (int i = 0; i < Count; i++)
        {
            // hpBarImage를 hpBarObject의 자식으로 생성
            Image newHpBar = Instantiate(timerImage, timerBar.transform);

            // 위치 지정 (예: 가로로 나열)
            RectTransform rt = newHpBar.GetComponent<RectTransform>();
            rt.anchoredPosition = timerPos;

            timerPos.x += 50f;
        }
    }

    public void ClearTimerBar()
    {
        foreach (Transform child in timerBar.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
