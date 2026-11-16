using System.Collections.Generic;
using UnityEngine;

//壁掛け時計の針をMystery2Managerが決めた時刻・色に合わせる
//左右の時計それぞれにアタッチし、clockSideで配置を指定する（時計は止まったまま）
public class WallClockSettings : MonoBehaviour, IResetInterface
{
    //シーン上のすべての壁掛け時計（Awakeで登録）
    static readonly List<WallClockSettings> wallClocks = new List<WallClockSettings>();

    [SerializeField] Mystery2Manager.ClockSide clockSide = Mystery2Manager.ClockSide.Left;

    [SerializeField] Transform hourHand;   //短針（Clock/Arrow/HourHand）
    [SerializeField] Transform minuteHand; //長針（Clock/Arrow/MinuteHand）

    //針の色
    [SerializeField] Color hourHandColor = Color.black;
    [SerializeField] Color yellowMinuteHandColor = new Color(1f, 0.92f, 0f, 1f);
    [SerializeField] Color greenMinuteHandColor = new Color(0f, 1f, 0f, 1f);

    //モデルの向きに合わせた補正（針が12時を指すときのZ角度と回転方向）
    [SerializeField] float angleOffset = 0f;
    [SerializeField] bool reverseDirection = false;

    Vector3 hourHandBaseEuler;
    Vector3 minuteHandBaseEuler;
    Renderer[] hourHandRenderers;
    Renderer[] minuteHandRenderers;

    static readonly int ColorId = Shader.PropertyToID("_Color");
    static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

    private void Awake()
    {
        if (!wallClocks.Contains(this))
        {
            wallClocks.Add(this);
        }

        //X・Y軸の傾きはモデル本来の値を保持し、Z軸だけを回す
        hourHandBaseEuler = hourHand.localEulerAngles;
        minuteHandBaseEuler = minuteHand.localEulerAngles;

        hourHandRenderers = hourHand.GetComponentsInChildren<Renderer>(true);
        minuteHandRenderers = minuteHand.GetComponentsInChildren<Renderer>(true);
    }

    private void OnDestroy()
    {
        wallClocks.Remove(this);
    }

    //すべての壁掛け時計を初期化する（Mystery2Manager.InitialzedObject()の後に呼ぶこと）
    public static void InitializeAllClocks()
    {
        if (wallClocks.Count == 0)
        {
            throw new System.InvalidOperationException("WallClockSettingsがシーンに見つかりません");
        }

        foreach (WallClockSettings clock in wallClocks)
        {
            clock.InitialzedObject();
        }
    }

    public void InitialzedObject()
    {
        Mystery2Manager.ClockTime time = Mystery2Manager.passwordInstance.GetClockTime(clockSide);

        SetHandAngle(hourHand, hourHandBaseEuler, time.HourHandAngle);
        SetHandAngle(minuteHand, minuteHandBaseEuler, time.MinuteHandAngle);

        Color minuteColor = time.MinuteColor == Mystery2Manager.MinuteHandColor.Yellow
            ? yellowMinuteHandColor
            : greenMinuteHandColor;

        SetHandColor(hourHandRenderers, hourHandColor);
        SetHandColor(minuteHandRenderers, minuteColor);
    }

    private void SetHandAngle(Transform hand, Vector3 baseEuler, float clockAngle)
    {
        float direction = reverseDirection ? -1f : 1f;
        hand.localEulerAngles = new Vector3(baseEuler.x, baseEuler.y, angleOffset + clockAngle * direction);
    }

    //マテリアルアセットを書き換えないようMaterialPropertyBlockで色を設定する
    private void SetHandColor(Renderer[] renderers, Color color)
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        foreach (Renderer r in renderers)
        {
            r.GetPropertyBlock(block);
            block.SetColor(ColorId, color);
            block.SetColor(BaseColorId, color);
            r.SetPropertyBlock(block);
        }
    }
}
