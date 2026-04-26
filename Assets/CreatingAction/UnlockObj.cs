using UnityEngine;

//鍵を開けたり、ドアを制御するクラス
public class UnlockObj : MonoBehaviour, IResetInterface
{
    Animator animator;
    public static UnlockObj unlockInstance;

    private void Awake()
    {
        if (unlockInstance is null)
        {
            unlockInstance = this;
        }

        animator = GetComponent<Animator>();
    }

    //脱出のため鍵を開ける処理を設定。解除条件は”鍵を取得 ＋ 鍵をインベントリで選択している”
    public void UnlockKey()
    {
        ItemData item = ItemSlotSetting.itemSlotInstance.GetSelectedSlot();

        Debug.Log(item + "でUnlockKeyメソッドが呼び出されました");
        //処理1_現在ユーザーが選択しているアイテムが鍵か判定
        //処理2_OpenObjからドアを開ける
        if (item?.type == ItemData.Type.Key)
        {
            Debug.Log(item + "でOpenObjメソッドを呼び出します");
            ObjStateManager.managerInstance.SetFlag(ObjStateData.Type.UnlockedEscapeDoor.ToString());
            animator.Play("UnlockAnimation", 0);
        }
        else
        {
            Debug.Log("ITEM_TYPE：" + item?.type);
            Debug.Log("ItemData.Type.Key：" + ItemData.Type.Key);
        }
    }

    public void InitialzedObject()
    {
        ObjStateManager.managerInstance.DeleteFlag();
        animator.Play("LockAnimation", 0);
    }
}



