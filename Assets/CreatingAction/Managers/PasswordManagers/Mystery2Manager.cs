using UnityEngine;

public class Mystery2Manager : MonoBehaviour, IResetInterface
{
    string correctPassword = string.Empty;
    public static Mystery2Manager passwordInstance;

    const int MinutesPerHalfDay = 720;  //12時間 = 720分
    const float HourHandDegreesPerMinute = 0.5f; //短針は1分で0.5度進む
    const float MinuteHandDegreesPerMinute = 6f; //長針は1分で6度進む

    //壁掛け時計の配置（左右）
    public enum ClockSide
    {
        Left,
        Right
    }

    //長針の色
    public enum MinuteHandColor
    {
        Yellow,
        Green
    }

    //時計1つ分の表示情報（針の角度は12時の位置を0度とした時計回りの角度）
    public struct ClockTime
    {
        public float HourHandAngle;
        public float MinuteHandAngle;
        public MinuteHandColor MinuteColor;
    }

    ClockTime yellowClock;
    ClockTime greenClock;

    //trueなら黄色の長針の時計が左、緑の長針の時計が右
    public bool IsYellowLeft { get; private set; }

    private void Awake()
    {
        if (passwordInstance is null)
        {
            passwordInstance = this;
        }
    }

    //ゲームを開始するたびに2つの時計の時刻と左右の配置をランダムに決め、パスワードを作る
    //パスワード＝黄色の長針の時計の「時」2桁 ＋ 緑の長針の時計の「分」2桁
    public void InitialzedObject()
    {
        int yellowHour;
        int yellowMinute;
        int greenHour;
        int greenMinute;

        yellowClock = CreateRandomClock(MinuteHandColor.Yellow, out yellowHour, out yellowMinute);
        greenClock = CreateRandomClock(MinuteHandColor.Green, out greenHour, out greenMinute);

        IsYellowLeft = Random.Range(0, 2) == 0;

        correctPassword = yellowHour.ToString("00") + greenMinute.ToString("00");
        Debug.Log("Mystery2 黄色の時計 " + yellowHour.ToString("00") + ":" + yellowMinute.ToString("00")
            + " / 緑の時計 " + greenHour.ToString("00") + ":" + greenMinute.ToString("00")
            + " / 黄色は" + (IsYellowLeft ? "左" : "右"));
        Debug.Log("Mystery2メモボックスのパスワード：" + correctPassword);
    }

    private ClockTime CreateRandomClock(MinuteHandColor color, out int hour, out int minute)
    {
        //0時0分からの経過分（0～719）
        int totalMinutes = Random.Range(0, MinutesPerHalfDay);

        hour = totalMinutes / 60;   //00～11
        minute = totalMinutes % 60; //00～59

        ClockTime clock = new ClockTime();
        //短針は分に合わせて少しずつ進める（例：5:30なら5と6の中間を指す）
        clock.HourHandAngle = totalMinutes * HourHandDegreesPerMinute;
        clock.MinuteHandAngle = minute * MinuteHandDegreesPerMinute;
        clock.MinuteColor = color;
        return clock;
    }

    //指定した位置（左右）の時計に表示する時刻と長針の色を返す
    public ClockTime GetClockTime(ClockSide side)
    {
        bool yellowSide = (side == ClockSide.Left) == IsYellowLeft;
        return yellowSide ? yellowClock : greenClock;
    }

    //パスワードを比較する
    public bool Mystery2PasswordCompatison(string userInputPassword)
    {
        return correctPassword == userInputPassword;
    }
}
