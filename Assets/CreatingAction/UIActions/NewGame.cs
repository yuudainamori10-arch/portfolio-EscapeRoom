using UnityEngine;

//ゲームのタイトル画面のコード
public class NewGame : MonoBehaviour
{
    public GameObject startUIs;
    public void OnStartButtonClicked()
    {
        //ゲームの初期化ができた場合にゲームを開始する
        if (InitializationAll.initializeInstance.InitializeGame())
        {

            startUIs.SetActive(false);

            //ゲームの起動時にはカーソルを非表示にする
            CursorManager.cursorManagerInstance.HideCursor();
        }
    }
}
