using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager cursorManagerInstance;
    private void Awake()
    {
        if (cursorManagerInstance is null)
        {
            cursorManagerInstance = this;
        }
    }

    //ゲーム中はカーソルを表示しない
    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //UI表示中はカーソルを表示する
    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
