using UnityEngine;

public class TitleBack : MonoBehaviour
{
    public GameObject startUIs;
    public GameObject clearUIs;

    public void OnOneMoreGameButtonClicked()
    {
        clearUIs.SetActive(false);
        startUIs.SetActive(true);
    }
}
