using UnityEngine;
using System;

[Serializable]
public class ItemData
{
    //ゲーム内で取得できるアイテムの一覧
    public enum Type
    {
        Key, //脱出用の鍵
        Memo //Mystery1のパスワードが1桁書かれたメモ
    }

    public Type type; //アイテムの種類
    public Sprite sprite; //ItemSlotに表示する画像

    [NonSerialized] public string memoNumber; //メモに書かれた数字（Memoのみ）
    [NonSerialized] public Color memoColor;   //メモの文字色（Memoのみ）

    public ItemData(Type type , Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }

    //メモのアイテムを作成する
    public ItemData(string memoNumber, Color memoColor)
    {
        this.type = Type.Memo;
        this.sprite = null;
        this.memoNumber = memoNumber;
        this.memoColor = memoColor;
    }
}
