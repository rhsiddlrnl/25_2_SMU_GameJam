using UnityEngine;
using System.Collections;


public class SkillManager : MonoBehaviour
{
    [Header("OBJ")]
    public GameObject portalObj;
    public GameObject parallelObj;

    [Header("UI ����")]
    public GameObject whiteFogPanel; 
    public GameObject subtitleImageObj;

    [Header("Time Settings")]
    public float moveSpeed = 3.0f;
    public float openDelay = 1.0f;
    public float arriveDelay = 0.5f;
    public float endDelay = 2.0f;

    [Header("Blink Settings")] //������ ���� �ӵ�
    public float blinkInterval = 0.1f;

    [SerializeField]
    private TimerItemControll timerItemController;

    private bool isSkillActive = false;
    private float defaultTimeScale;

    void Start()
    {
        defaultTimeScale = Time.timeScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !isSkillActive && (timerItemController.GetTimerCount() >= 1))
        {
            timerItemController.ChangeTimerItemCount(-1);
            StartCoroutine(ProcessSkillSequence());
            SoundManager.instance.PlayWeakwordSound();
        }
    }

    IEnumerator ProcessSkillSequence()
    {
        isSkillActive = true;
        Time.timeScale = 0.05f; 

        
        Coroutine blinkRoutine = StartCoroutine(BlinkPanelEffect());

        
        if (subtitleImageObj != null) subtitleImageObj.SetActive(true);


        
        if (portalObj != null && parallelObj != null)
        {
            parallelObj.transform.position = portalObj.transform.position;
        }

        if (portalObj != null) portalObj.SetActive(true);
        yield return new WaitForSecondsRealtime(openDelay);

        if (parallelObj != null) parallelObj.SetActive(true);

        Vector3 targetPos = new Vector3(0, 3, 0);
        while (Vector3.Distance(parallelObj.transform.position, targetPos) > 0.1f)
        {
            parallelObj.transform.position = Vector3.MoveTowards(
                parallelObj.transform.position,
                targetPos,
                moveSpeed * Time.unscaledDeltaTime
            );
            yield return null;
        }

        yield return new WaitForSecondsRealtime(arriveDelay);
        ClearScreen(); 
        yield return new WaitForSecondsRealtime(endDelay);

        if (parallelObj != null) parallelObj.SetActive(false);
        if (portalObj != null) portalObj.SetActive(false);
        


       
        if (blinkRoutine != null) StopCoroutine(blinkRoutine);

        if (whiteFogPanel != null) whiteFogPanel.SetActive(false);
        if (subtitleImageObj != null) subtitleImageObj.SetActive(false);

        Time.timeScale = defaultTimeScale; 
        isSkillActive = false;
    }

    
    IEnumerator BlinkPanelEffect()
    {
        if (whiteFogPanel == null) yield break;

        bool isVisible = true;
        while (true) 
        {
            whiteFogPanel.SetActive(isVisible);
            isVisible = !isVisible; 

            
            yield return new WaitForSecondsRealtime(blinkInterval);
        }
    }

    void ClearScreen()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) Destroy(enemy);

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullets");
        foreach (GameObject bullet in bullets) Destroy(bullet);
    }
}