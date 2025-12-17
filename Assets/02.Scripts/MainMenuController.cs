using UnityEngine;
using UnityEngine.SceneManagement; // 씬 이동을 위해 꼭 필요한 네임스페이스입니다.

public class MainMenuController : MonoBehaviour
{
    // 버튼과 연결할 함수는 반드시 public이어야 합니다.
    public void StartGame()
    {
        // 스크린샷에 있는 씬 이름이 소문자 'game'이므로 똑같이 적어줍니다.
        SceneManager.LoadScene("game");
    }
}