using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject clearUIs;

    //脱出成功時にUIを表示する
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimerAction.timerInstance.StopTimer();
            ClearTimeSettings.timerInstance.DisplayClearTime();
            BestTimeAdministrator.SetBestTime(TimerAction.timerInstance.GetTimer());

            clearUIs.SetActive(true);

            //カーソルを表示する
            CursorManager.cursorManagerInstance.UnlockCursor();
        }        
    }
}
