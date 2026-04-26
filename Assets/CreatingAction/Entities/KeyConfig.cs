using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KeyConfig : ScriptableObject
{
    public List<KeySlotPair> keyConfig = new List<KeySlotPair>();
}

[System.Serializable]
public class KeySlotPair
{
    public KeyCode keyMapping;
    public int slotIndex;
}
