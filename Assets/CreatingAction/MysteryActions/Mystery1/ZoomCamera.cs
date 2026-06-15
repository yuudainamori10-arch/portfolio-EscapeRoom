using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomCamera : MonoBehaviour, IResetInterface
{
    public static ZoomCamera zoomCameraInstance;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera zoomCamera;
    [SerializeField] private GameObject centerPoint;
    [SerializeField] GameObject zoomEndButton;

    private void Awake()
    {
        if (zoomCameraInstance is null)
        {
            zoomCameraInstance = this;
        }
    }

    void Update()
    {
        //拡大ボタンのビルボード設定
        Vector3 p = mainCamera.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
        transform.Rotate(0, 180, 0);


        if (zoomCamera.gameObject.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            ClickAction();
        }
    }

    public void ChangeZoomCamera()
    {
        Debug.Log("拡大ボタンを押しました");
        if (mainCamera != null && zoomCamera != null)
        {
            mainCamera.gameObject.SetActive(false);
            zoomCamera.gameObject.SetActive(true);
            centerPoint.SetActive(false);
            zoomEndButton.SetActive(true);
            CursorManager.cursorManagerInstance.UnlockCursor();
        }
    }

    public void ClickAction()
    {
        Ray ray = zoomCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            ExecuteEvents.ExecuteHierarchy(
                hit.collider.gameObject,
                new PointerEventData(EventSystem.current),
                ExecuteEvents.pointerDownHandler
            );
        }
    }

    public void InitialzedObject()
    {
        zoomCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        centerPoint.SetActive(true);
        zoomEndButton.SetActive(false);
    }
}
