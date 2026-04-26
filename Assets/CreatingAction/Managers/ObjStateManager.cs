using System.Collections.Generic;
using UnityEngine;

public class ObjStateManager : MonoBehaviour
{
    public static ObjStateManager managerInstance;
    private HashSet<string> flags = new HashSet<string>();

    private void Awake()
    {
        if (managerInstance is null)
        {
            managerInstance = this;
        }
    }

    public void SetFlag(string flag)
    {
        flags.Add(flag);
    }

    public bool HasFlag(string item)
    {
        return flags.Contains(item);
    }

    public void DeleteFlag()
    {
        flags.Clear();
    }
}
