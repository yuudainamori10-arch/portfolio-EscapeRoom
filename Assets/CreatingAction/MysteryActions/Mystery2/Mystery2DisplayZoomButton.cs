using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Mystery2DisplayZoomButton : MonoBehaviour
{
    [SerializeField] GameObject zoomButton;

    void OnTriggerStay(Collider other)
    {
        //プレイヤーが接近したときかつ、引き出しが開いているときにボタンを表示する
        if (other.CompareTag("Player"))
        {
            zoomButton.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zoomButton.SetActive(false);
        }
    }
}