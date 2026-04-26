using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    //キー入力のボタンとアイテムスロットのインデックスを対応させる
    [SerializeField] private KeyConfig keyConfig;
    private Dictionary<KeyCode, int> keyMap;

    private void Start()
    {
        keyMap = new Dictionary<KeyCode, int>();

        foreach(var element in keyConfig.keyConfig)
        {
            keyMap[element.keyMapping] = element.slotIndex;
        }
    }

    void Update()
    {
        foreach (var map in keyMap)
        {
            if (Input.GetKeyDown(map.Key))
            {
                Debug.Log("ボタン押下：" + map.Key);
                Debug.Log("値：" + map.Value);

                ItemSlotSetting.itemSlotInstance.OnSelectSlot(map.Value);
                break;
            }
        }
    }
}
