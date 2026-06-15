using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomEndCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera zoomCamera;
    [SerializeField] private GameObject centerPoint;
    [SerializeField] GameObject zoomEndButton;

    public void ChangeMainCamera()
    {
        Debug.Log("ƒNƒŠƒbƒN‚Å‚«‚Ä‚é");
        if (mainCamera != null && zoomCamera != null)
        {
            zoomCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            centerPoint.SetActive(true);
            zoomEndButton.SetActive(false);
            CursorManager.cursorManagerInstance.HideCursor();
        }
    }
}
