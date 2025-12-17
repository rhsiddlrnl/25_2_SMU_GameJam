using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 씬 이동용

public class EndScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText; 
    public TextMeshProUGUI bestScoreText;    

    void Start()
    {
        // 저장된 점수 꺼내오기
        float current = PlayerPrefs.GetFloat("CurrentScore", 0);
        float best = PlayerPrefs.GetFloat("BestScore", 0);

        // 화면에 표시
        currentScoreText.text = "CurrentScore : " + (int)current;
        bestScoreText.text = "BestScore : " + (int)best;
    }

    
    public void ReGame()
    {
        SceneManager.LoadScene("game"); 
    }
}