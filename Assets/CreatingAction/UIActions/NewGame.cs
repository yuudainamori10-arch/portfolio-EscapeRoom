using System.Collections;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public GameObject startUIs;
    public void OnStartButtonClicked()
    {
        //ゲームの初期化ができた場合にゲームを開始する
        if (InitializationAll.initializeInstance.InitializeGame())
        {
            //Animation実行完了の待機
            StartCoroutine(MyCoroutine());

            //ゲームの起動時にはカーソルを非表示にする
            CursorManager.cursorManagerInstance.HideCursor();
        }
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        startUIs.SetActive(false);
        TimerAction.timerInstance.StartTimer();
    }
}
