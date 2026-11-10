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

            //脱出用のカギをしまった箱の暗証番号作成
            Mystery1Manager.passwordInstance.InitialzedObject();

            //引き出しの初期化
            DrawerOpen.drawerOpenInstance.InitialzedObject();

            //鍵の入った箱のふたを閉める
            Mystery2BoxLidStateManagement.boxLidStateManagementInstance.InitialzedObject();
            
            //Mystery1の設定を初期化
            Mystery1ZoomCamera.zoomCameraInstance.InitialzedObject();

            //Mystery2の設定を初期化
            Mystery2ZoomCamera.zoomCameraInstance.InitialzedObject();

            //脱出用のカギをしまった箱のダイヤルを初期化
            EscapeKeyBoxDisplay.keyBoxDisplayInstance.InitialzedObject();

            //Mystery2：時計の時刻とメモボックスの暗証番号を作成（針の設定より先に呼ぶ）
            Mystery2Manager.passwordInstance.InitialzedObject();

            //Mystery2：壁掛け時計の針を時刻に合わせる
            WallClockSettings.wallClockInstance.InitialzedObject();

            //Mystery2：メモボックスのダイヤルを初期化
            Mystery2MemoBoxDisplay.keyBoxDisplayInstance.InitialzedObject();

            //Mystery2：壁掛け時計の拡大表示を初期化
            WallClockStateManagement.wallClockZoomInstance.InitialzedObject();

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
