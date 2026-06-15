using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static ItemGenerator generatorInstance;
    [SerializeField] ItemEntity itemList;

    private void Awake()
    {
        if (generatorInstance is null)
        {
            generatorInstance = this;
        }
    }

    public ItemData SpawnItem(ItemData.Type type)
    {
        foreach (ItemData item in itemList.itemList)
        {
            if (item.type == type)
            {
                return new ItemData(item.type, item.sprite);
            }
        }
        return null;
    }
}
