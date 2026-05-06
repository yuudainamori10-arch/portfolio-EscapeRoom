using UnityEngine;

public class ClickObj : MonoBehaviour, IResetInterface
{
    public static ClickObj clickObjInstance;
    [SerializeField] ItemData.Type itemType;
    ItemData item;

    public void Start()
    {
        //itemTypeに応じてitemを作成する
        item = ItemGenerator.generatorInstance.SpawnItem(itemType);
    }

    private void Awake()
    {
        if (clickObjInstance is null)
        {
            clickObjInstance = this;
        }
    }

    public void OnClickObj()
    {
        Debug.Log("[" + item + "]クリック判定〇");
        ItemSlotSetting.itemSlotInstance.SetItem(item);
        gameObject.SetActive(false);
    }

    public void InitialzedObject()
    {
        gameObject.SetActive(true);

        // アイテムを生成
        item = ItemGenerator.generatorInstance.SpawnItem(itemType);
    }
}
