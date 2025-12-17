using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public TextMeshProUGUI timeText;   
    public TextMeshProUGUI bestScoreText;  

    public bool isGameOver = false;
    float survivalTime;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    
    void Start()
    {
       
        float best = PlayerPrefs.GetFloat("BestScore", 0);

        
        if (bestScoreText != null)
        {
            bestScoreText.text = "Best: " + (int)best;
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            survivalTime += Time.deltaTime * 10;
            timeText.text = "Score: " + (int)survivalTime;
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        PlayerPrefs.SetFloat("CurrentScore", survivalTime);

        float bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        if (survivalTime > bestScore)
        {
            PlayerPrefs.SetFloat("BestScore", survivalTime);
        }

        SceneManager.LoadScene("End");
    }
}