using UnityEngine;

public class Mystery2Manager : MonoBehaviour, IResetInterface
{
    string correctPassword = string.Empty;
    public static Mystery2Manager passwordInstance;

    const int MinutesPerHalfDay = 720;  //12時間 = 720分
    const float HourHandDegreesPerMinute = 0.5f; //短針は1分で0.5度進む
    const float MinuteHandDegreesPerMinute = 6f; //長針は1分で6度進む

    //時計の針の角度（12時の位置を0度とした時計回りの角度）
    public float HourHandAngle { get; private set; }
    public float MinuteHandAngle { get; private set; }

    private void Awake()
    {
        if (passwordInstance is null)
        {
            passwordInstance = this;
        }
    }

    //ゲームを開始するたびにランダムな時刻を作成し、時刻からパスワードを作る
    public void InitialzedObject()
    {
        //0時0分からの経過分（0～719）
        int totalMinutes = Random.Range(0, MinutesPerHalfDay);

        int hour = totalMinutes / 60;   //00～11
        int minute = totalMinutes % 60; //00～59

        //短針は分に合わせて少しずつ進める（例：5:30なら5と6の中間を指す）
        HourHandAngle = totalMinutes * HourHandDegreesPerMinute;
        MinuteHandAngle = minute * MinuteHandDegreesPerMinute;

        correctPassword = hour.ToString("00") + minute.ToString("00");
        Debug.Log("Mystery2メモボックスのパスワード：" + correctPassword);
    }

    //パスワードを比較する
    public bool Mystery2PasswordCompatison(string userInputPassword)
    {
        return correctPassword == userInputPassword;
    }
}
