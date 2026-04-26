using System;
using UnityEngine;

[Serializable]
public class ObjStateData
{
    //ゲーム内フラグの一覧
    public enum Type
    {
        UnlockedEscapeDoor //脱出用ドアをオープンしたフラグ
    }

    public Type flag; //フラグ取得

    public ObjStateData(Type flag)
    {
        this.flag = flag;
    }
}
