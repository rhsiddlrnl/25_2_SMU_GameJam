using UnityEngine;

public class TimerItemControll : MonoBehaviour
{
    [SerializeField]
    private int Count = 5;
    [SerializeField]
    private TimerItemBarControll timerBarController;

    private void Start()
    {
        timerBarController.SetTimerBar(Count);
    }
    public int GetTimerCount()
    {
        return Count;
    }

    public void ChangeTimerItemCount(int num)
    {
        Count += num;
        timerBarController.ClearTimerBar();
        timerBarController.SetTimerBar(Count);
    }
}
