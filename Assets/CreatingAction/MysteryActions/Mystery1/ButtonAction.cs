using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAction : MonoBehaviour
{
    public ButtonType buttonType;

    public enum ButtonType
    {
        Add,
        Subtract,
        Verification
    }

    public void OnAddButton(BaseEventData data)
    {
        DigitType buttonInfo = GetComponent<DigitType>();
        EscapeKeyBoxDisplay.keyBoxDisplayInstance.AddNumber(buttonInfo.buttonType);
    }

    public void OnSubtractButton(BaseEventData data)
    {
        DigitType buttonInfo = GetComponent<DigitType>();
        EscapeKeyBoxDisplay.keyBoxDisplayInstance.SubtractNumber(buttonInfo.buttonType);
    }

    public void OnVerificationButton(BaseEventData data)
    {
        string displayPassword = EscapeKeyBoxDisplay.keyBoxDisplayInstance.GetDisplayNumber();
        bool openFlag = PasswordManagers.passwordInstance.PasswordCompatison(displayPassword);

        if (openFlag)
        {
            BoxLidStateManagement.boxLidStateManagementInstance.OpenLid();
        }
    }
}
