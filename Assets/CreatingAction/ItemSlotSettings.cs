using UnityEngine;

public class ItemSlotSetting : MonoBehaviour, IResetInterface
{
    public static ItemSlotSetting itemSlotInstance;
    [SerializeField] SlotDisplaySettings[] slots;
    [SerializeField] SlotDisplaySettings selectedSlot = null;

    private void Awake()
    {
        if (itemSlotInstance is null)
        {
            itemSlotInstance = this;

            slots = GetComponentsInChildren<SlotDisplaySettings>();
        }
    }

    //アイテムスロットの左側から空いていていた場合にアイテムをセット
    public void SetItem(ItemData item)
    {
        foreach(var slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                break;
            }
        }
    }

    //プレイヤーが選択しているアイテムスロットを画面表示する
    public void OnSelectSlot(int position)
    {
        Debug.Log("スロットの場所:" + position);
        foreach (var slot in slots)
        {
            slot.HideBgPanel();
        }

        if (slots[position].OnSelected())
        {
            selectedSlot = slots[position];
        }
    }

    //プレイヤーが現在選択しているスロットのアイテムを返す
    public ItemData GetSelectedSlot()
    {
        if (selectedSlot is not null)
        {
            return selectedSlot.GetItemData();
        }
        return null;
    }

    public void InitialzedObject()
    {
        foreach (var slot in slots)
        {
            slot.HideBgPanel();
            slot.EraseItem();
        }
    }
}
