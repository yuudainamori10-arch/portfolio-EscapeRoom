using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class TimerAction : MonoBehaviour, IResetInterface
{
    public static TimerAction timerInstance;
    [SerializeField] TextMeshProUGUI timerText;
    float nowTime;

    bool startFlag = false;
    bool timeupFlag = false;
    bool clearFlag = false;

    float measurementLimitTime = 3600f; //計測時間の上限を1時間に設定する

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

            int minites = (int)(nowTime / 60);
            int second = (int)(nowTime % 60);
            int millisecond = (int)((nowTime * 10) % 10);
            timerText.text = $"{minites.ToString("00")}:{second.ToString("00")}.{millisecond.ToString("0")}";

            if (nowTime >= measurementLimitTime)
            {
                timeupFlag = true;
                timerText.text = "計測不能";
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