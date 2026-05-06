using TMPro;
using UnityEngine;

public class ClearTimeSettings : MonoBehaviour
{
    public static ClearTimeSettings timerInstance;
    [SerializeField] TextMeshProUGUI timerText;
    float measurementLimitTime = 3600f; //計測時間の上限を1時間に設定する

    private void Awake()
    {
        if (timerInstance is null)
        {
            timerInstance = this;
        }
    }

    public void DisplayClearTime() 
    {
        float clearTime = TimerAction.timerInstance.GetTimer();

        int minites = (int)(clearTime / 60);
        int second = (int)(clearTime % 60);
        int millisecond = (int)((clearTime * 10) % 10);
        timerText.text = $"{minites.ToString("00")}:{second.ToString("00")}.{millisecond.ToString("0")}";

        if (clearTime >= measurementLimitTime)
        {
            timerText.text = "計測不能";
        }
    }
}
