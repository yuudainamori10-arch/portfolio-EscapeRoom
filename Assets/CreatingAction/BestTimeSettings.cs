using TMPro;
using UnityEngine;

public class BestTimeSettings : MonoBehaviour
{
    public static BestTimeSettings bestTimeInstance;
    [SerializeField] TextMeshProUGUI bestTimeText;


    private void Awake()
    {
        if (bestTimeInstance is null)
        {
            bestTimeInstance = this;
        }
        DisplayBestTime();
    }

    public void DisplayBestTime()
    {
        bestTimeText.text = BestTimeAdministrator.GetBestTime();
    }
}
