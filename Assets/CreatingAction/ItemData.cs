using UnityEngine;
using System;

[Serializable]
public class ItemData
{
    //ゲーム内で取得できるアイテムの一覧
    public enum Type
    {
        Key //脱出用の鍵
    }

    public Type type; //アイテムの種類
    public Sprite sprite; //ItemSlotに表示する画像

    public ItemData(Type type , Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
}
