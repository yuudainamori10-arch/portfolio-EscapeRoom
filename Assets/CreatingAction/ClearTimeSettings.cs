using TMPro;
using UnityEngine;

public class ClearTimeSettings : MonoBehaviour
{
    public static ClearTimeSettings timerInstance;
    [SerializeField] TextMeshProUGUI timerText;
    

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

        timerText.text = BestTimeAdministrator.ConvertTimerText(clearTime);
    }
}
