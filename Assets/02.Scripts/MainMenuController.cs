using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuController : MonoBehaviour
{
   
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("game");
    }
}