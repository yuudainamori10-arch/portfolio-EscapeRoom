using UnityEngine;

//壁掛け時計の針をMystery2Managerが決めた時刻に合わせる
public class WallClockSettings : MonoBehaviour, IResetInterface
{
    public static WallClockSettings wallClockInstance;

    [SerializeField] Transform hourHand;   //短針（Clock/Arrow/HourHand）
    [SerializeField] Transform minuteHand; //長針（Clock/Arrow/MinuteHand）

    //モデルの向きに合わせた補正（針が12時を指すときのZ角度と回転方向）
    [SerializeField] float angleOffset = 0f;
    [SerializeField] bool reverseDirection = false;

    Vector3 hourHandBaseEuler;
    Vector3 minuteHandBaseEuler;

    private void Awake()
    {
        if (wallClockInstance is null)
        {
            wallClockInstance = this;
        }

        //X・Y軸の傾きはモデル本来の値を保持し、Z軸だけを回す
        hourHandBaseEuler = hourHand.localEulerAngles;
        minuteHandBaseEuler = minuteHand.localEulerAngles;
    }

    //Mystery2Manager.InitialzedObject()の後に呼ぶこと
    public void InitialzedObject()
    {
        SetHandAngle(hourHand, hourHandBaseEuler, Mystery2Manager.passwordInstance.HourHandAngle);
        SetHandAngle(minuteHand, minuteHandBaseEuler, Mystery2Manager.passwordInstance.MinuteHandAngle);
    }

    private void SetHandAngle(Transform hand, Vector3 baseEuler, float clockAngle)
    {
        float direction = reverseDirection ? -1f : 1f;
        hand.localEulerAngles = new Vector3(baseEuler.x, baseEuler.y, angleOffset + clockAngle * direction);
    }
}
