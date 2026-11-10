using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//謎を解くと取得できるメモ。クリックするとアイテムスロットに入る
public class MemoObject : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] int memoIndex;          //何枚目のメモか（0～3）
    [SerializeField] TextMeshPro numberText; //メモに表示する数字
    ItemData item;

    //MemoManagerから呼ばれ、メモの内容を設定して表示する
    public void InitialzedObject()
    {
        MemoInfo memo = MemoManager.memoInstance.GetMemo(memoIndex);
        numberText.text = memo.number;
        numberText.color = memo.color;
        item = new ItemData(memo.number, memo.color);

        //箱のふたが開くまでは取れないようにする
        SetPickable(false);
        gameObject.SetActive(true);
    }

    //メモを取れるかどうかを切り替える（クリック判定の有効・無効）
    public void SetPickable(bool pickable)
    {
        GetComponent<Collider>().enabled = pickable;
    }

    //クリックされたらアイテムスロットに入れて非表示にする
    public void OnPointerDown(PointerEventData eventData)
    {
        if (item is null)
        {
            return;
        }

        ItemSlotSetting.itemSlotInstance.SetItem(item);
        gameObject.SetActive(false);
    }
}
