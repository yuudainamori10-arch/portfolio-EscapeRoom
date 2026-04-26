using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

public class FPSController : MonoBehaviour
{
    float x, z;

    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 1f, Ysensityvity = 1f;
    float minX = -90f, maxX = 90f;

    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        //Escapeボタンでカーソルを表示する
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CursorManager.cursorManagerInstance.UnlockCursor();
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            ClickAction();
        }
    }

    public void ClickAction()
    {
        Camera camera = cam.GetComponent<Camera>();
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            ExecuteEvents.ExecuteHierarchy(
                hit.collider.gameObject,
                new PointerEventData(EventSystem.current),
                ExecuteEvents.pointerDownHandler
            );
        }
    }

    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
}
