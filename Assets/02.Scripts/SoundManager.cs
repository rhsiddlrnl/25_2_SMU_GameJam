using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 싱글톤 패턴: 어디서든 SoundManager.instance 로 부를 수 있게 함
    public static SoundManager instance;

    [Header("speaker")]
    public AudioSource bgmPlayer; // 배경음악용 스피커 (반복 재생)
    public AudioSource sfxPlayer; // 효과음용 스피커 (한 번 재생)

    [Header("audio clip collection")]
    public AudioClip mainBgm;   // 배경음악 파일
    public AudioClip attackSfx; // 미사일 발사 소리
    public AudioClip hitSfx;    // 피격 소리
    public AudioClip shieldSfx; //방어막 소리

    void Awake()
    {
        // 게임 시작 시 나 자신을 instance에 넣음
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 음악 안 끊기게 함
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }

    void Start()
    {
        // 게임 시작하자마자 배경음악 재생
        PlayBGM(mainBgm);
    }

    // 배경음악 재생 함수
    public void PlayBGM(AudioClip clip)
    {
        bgmPlayer.clip = clip;
        bgmPlayer.loop = true; // 무한 반복
        bgmPlayer.volume = 0.5f; // 볼륨 조절 (0.0 ~ 1.0)
        bgmPlayer.Play();
    }

    // 효과음 재생 함수 (외부에서 이름으로 부르기 편하게 만듦)
    public void PlayAttackSound()
    {
        sfxPlayer.PlayOneShot(attackSfx);
    }

    public void PlayHitSound()
    {
        sfxPlayer.PlayOneShot(hitSfx);
    }

    public void PlayShieldSound()
    {
        sfxPlayer.PlayOneShot(shieldSfx);
    }
}