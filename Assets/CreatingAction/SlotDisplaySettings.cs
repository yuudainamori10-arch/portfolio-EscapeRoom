using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class SlotDisplaySettings : MonoBehaviour
{
    public static SlotDisplaySettings slotDisplayInstance;
    ItemData itemData;
    Image itemIcon;
    [SerializeField] GameObject backgroundPanel;

    private void Awake()
    {
        if (slotDisplayInstance is null)
        {
            slotDisplayInstance = this;
        }

        //アイテムスロットに表示するアイコンの初期設定
        itemIcon = transform.Find("ItemIcon").GetComponent<Image>();
        Debug.Log(itemIcon + "を表示する");
    }

    //アイテムスロットが空か判定する
    public bool IsEmpty()
    {
        if(itemData is null)
        {
            return true;
        }
        return false;
    }

    //アイテムスロットにアイテムを表示する
    public void SetItem(ItemData item)
    {
        itemData = item;
        Debug.Log(item + "を取得");
        UpdateImage(item);
    }

    //アイテムスロットの表示を変更する
    private void UpdateImage(ItemData item)
    {
        itemIcon.sprite = item.sprite;
        itemIcon.gameObject.SetActive(true);
        Debug.Log("test:"+itemIcon);
    }

    //アイテム選択できるか判定する
    public bool OnSelected()
    {
        Debug.Log("itemData : " + itemData);

        //アイテム持っていない場合は選択できない
        if (itemData is null)
        {
            return false;
        }

        backgroundPanel.SetActive(true);
        return true;
    }

    //アイテムスロットの背景を消す
    public void HideBgPanel()
    {
        backgroundPanel.SetActive(false);
    }

    //スロットの持つItemDataを返す
    public ItemData GetItemData()
    {
        return itemData;
    }

    //アイテムスロットのアイテムを消去する
    public void EraseItem()
    {
        itemData = null;
        EraseImage();
    }

    //アイテムスロットの表示を消去する
    private void EraseImage()
    {
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);
    }
}
