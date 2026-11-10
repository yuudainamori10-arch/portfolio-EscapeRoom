using UnityEngine;

public class Mystery2BoxLidStateManagement : MonoBehaviour, IResetInterface
{
    public static Mystery2BoxLidStateManagement boxLidStateManagementInstance;
    Animator animator;
    [SerializeField] MemoObject memo; //箱の中のメモ（ふたが開くまで取れない）

    private void Awake()
    {
        if (boxLidStateManagementInstance is null)
        {
            boxLidStateManagementInstance = this;
        }
        animator = GetComponent<Animator>();
    }

    public void InitialzedObject()
    {
        //箱のふたを閉じる
        animator.Play("Idle", 0, 0f);
    }

    public void OpenLid()
    {
        animator.Play("OpenLid", 0);

        //ふたが開いたらメモを取れるようにする
        if (memo != null)
        {
            memo.SetPickable(true);
        }
    }
}
