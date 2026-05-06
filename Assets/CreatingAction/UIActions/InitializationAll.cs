using System;
using UnityEngine;

public class InitializationAll : MonoBehaviour
{
    public static InitializationAll initializeInstance;

    private void Awake()
    {
        if (initializeInstance is null)
        {
            initializeInstance = this;
        }
    }

    //ゲームを初期化する
    public bool InitializeGame()
    {
        Debug.Log("Initialized game settings");
        try
        {
            //プレイヤーの位置を初期位置にリスポーン
            PlayerController.playerControllerInstance.InitialzedObject();

            //ゲーム内のアイテムをすべて表示する
            ClickObj.clickObjInstance.InitialzedObject();

            //アイテムスロットの初期化
            ItemSlotSetting.itemSlotInstance.InitialzedObject();

            //トイレのドアを閉じる
            RestRoomDoorOpen.openInstance.InitialzedObject();

            //脱出口を閉じる
            DoorOpen.doorOpenInstance.InitialzedObject();

            //鍵穴をロック状態に戻す
            UnlockObj.unlockInstance.InitialzedObject();

            //タイマーの初期化
            TimerAction.timerInstance.InitialzedObject();

            return true;
        }
        catch(Exception ex)
        {
            Debug.Log("Failed to Initialize game settings");
            Debug.LogException(ex);

            return false;
        }
    }

    
}
