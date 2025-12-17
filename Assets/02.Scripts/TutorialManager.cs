using UnityEngine;
using UnityEngine.UI; // UI를 건드려야 하니 필수!

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; 
    public Image displayImage;       

    public Sprite[] tutorialSprites; 

    private int currentIndex = 0;    

    // 설명서 열기 (타이틀 화면의 '설명' 버튼에 연결)
    public void OpenTutorial()
    {
        if (tutorialSprites.Length == 0) return; // 이미지가 없으면 실행 안 함

        tutorialPanel.SetActive(true); // 패널 켜기
        currentIndex = 0;              // 첫 장부터 시작
        displayImage.sprite = tutorialSprites[currentIndex]; // 첫 이미지 보여주기
    }

    // 다음 장 넘기기 (설명서 화면 전체를 버튼으로 만들어서 연결)
    public void NextPage()
    {
        currentIndex++; // 페이지 번호 증가

        
        if (currentIndex < tutorialSprites.Length)
        {
            // 다음 이미지로 교체
            displayImage.sprite = tutorialSprites[currentIndex];
        }
        else
        {
            
            CloseTutorial();
        }
    }

    // 설명서 닫기
    void CloseTutorial()
    {
        tutorialPanel.SetActive(false); // 패널 끄기
    }
}