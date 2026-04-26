using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemEntity : ScriptableObject
{
    public List<ItemData> itemList = new List<ItemData>();
}
