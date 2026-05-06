using System.Collections;
using UnityEngine;

public class OneMoreGame : MonoBehaviour
{
    public GameObject clearUIs;
    public void OnOneMoreGameButtonClicked()
    {
        //ゲームの初期化ができた場合にゲームを開始する
        if (InitializationAll.initializeInstance.InitializeGame())
        {
            //Animation実行の待機
            StartCoroutine(MyCoroutine());

            //ゲームの起動時にはカーソルを非表示にする
            CursorManager.cursorManagerInstance.HideCursor();
        }
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        clearUIs.SetActive(false);
        TimerAction.timerInstance.StartTimer();
    }
}
