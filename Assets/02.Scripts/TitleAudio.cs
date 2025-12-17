using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    public AudioSource audioSource; // 효과음 낼 스피커
    public AudioClip clickSound;    // 딸각 소리 파일

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
