using Unity.VisualScripting;
using UnityEngine;

public class BestTimeAdministrator
{
    const float measurementLimitTime = 3600f; //計測時間の上限を1時間に設定する
    const string timeupText = "計測不能";
    const string notKeepBestTimeText = "記録なし";

    public static void SetBestTime(float measurementTime)
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);

        if (bestTime == 0f || measurementTime < bestTime)
        {
            PlayerPrefs.SetFloat("BestTime", measurementTime);
        }
    }

    public static string GetBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);

        if(bestTime == 0f)
        {
            return notKeepBestTimeText;
        }

        return ConvertTimerText(bestTime);
    }

    public static string ConvertTimerText(float time)
    {
        if (time < measurementLimitTime)
        {
            int minites = (int)(time / 60);
            int second = (int)(time % 60);
            int millisecond = (int)((time * 10) % 10);
            return $"{minites.ToString("00")}:{second.ToString("00")}.{millisecond.ToString("0")}";
        }
        else
        {
            return timeupText;
        }
    }
}
