using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class TimerAction : MonoBehaviour, IResetInterface
{
    public static TimerAction timerInstance;
    [SerializeField] TextMeshProUGUI timerText;
    float nowTime;
    string timeupText = "計測不能";

    bool startFlag = false;
    bool timeupFlag = false;
    bool clearFlag = false;

    void Start()
    {
        nowTime = 0f;
        timerText.text = ("00:00.0");
    }

    private void Awake()
    {
        if (timerInstance is null)
        {
            timerInstance = this;
        }
    }

    void Update()
    {
        if (startFlag && !timeupFlag && !clearFlag) { 
            nowTime += Time.deltaTime;

            timerText.text = BestTimeAdministrator.ConvertTimerText(nowTime);

            if (timerText.text == timeupText)
            {
                timeupFlag = true;
            }
        }
    }

    public void StartTimer()
    {
        startFlag = true;
    }

    //ゲームクリア時に使用する
    public void StopTimer()
    {
        clearFlag = true;
    }

    public float GetTimer()
    {
        return nowTime;
    }

    public void InitialzedObject()
    {
        nowTime = 0f;
        startFlag = false;
        timeupFlag = false;
        clearFlag = false;
        timerText.text = ("00:00.0");
    }
}