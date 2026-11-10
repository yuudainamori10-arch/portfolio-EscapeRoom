using UnityEngine;
using UnityEngine.EventSystems;

//壁掛け時計の拡大表示を制御する（時計はアイテムとして取得できず、拡大して見るだけ）
//拡大ボタンUIにアタッチする。プレイヤー接近時のボタン表示はMystery2DisplayZoomButton、
//拡大終了はMystery2ZoomEndCameraを流用する
public class WallClockStateManagement : MonoBehaviour, IResetInterface
{
    public static WallClockStateManagement wallClockZoomInstance;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera zoomCamera;
    [SerializeField] private GameObject centerPoint;
    [SerializeField] GameObject zoomButton;
    [SerializeField] GameObject zoomEndButton;

    private void Awake()
    {
        if (wallClockZoomInstance is null)
        {
            wallClockZoomInstance = this;
        }
    }

    void Update()
    {
        //拡大ボタンのビルボード設定
        Vector3 p = mainCamera.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
        transform.Rotate(0, 180, 0);

        //拡大中は拡大カメラからのクリックで拡大終了ボタンを押せるようにする
        if (zoomCamera.gameObject.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            ClickAction();
        }
    }

    private void ClickAction()
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

    public void ChangeZoomCamera()
    {
        if (mainCamera != null && zoomCamera != null)
        {
            mainCamera.gameObject.SetActive(false);
            zoomCamera.gameObject.SetActive(true);
            centerPoint.SetActive(false);
            zoomButton.SetActive(false);
            zoomEndButton.SetActive(true);
            CursorManager.cursorManagerInstance.UnlockCursor();
        }
    }

    public void InitialzedObject()
    {
        zoomCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        centerPoint.SetActive(true);
        zoomButton.SetActive(false);
        zoomEndButton.SetActive(false);
    }
}
