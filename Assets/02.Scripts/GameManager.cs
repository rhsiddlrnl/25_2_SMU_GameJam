using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;     
    public TextMeshProUGUI timeText;          
    public bool isGameOver = false;           

    float survivalTime;                       

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        
        if (!isGameOver)
        {
            survivalTime += Time.deltaTime * 10; 

            
            timeText.text = "Score: " + (int)survivalTime;
        }
    }

    
    public void GameOver()
    {
        isGameOver = true;
    }
}