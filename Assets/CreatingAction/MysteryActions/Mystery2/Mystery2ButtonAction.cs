using UnityEngine;
using UnityEngine.EventSystems;

public class Mystery2ButtonAction : MonoBehaviour
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
        Mystery2MemoBoxDisplay.keyBoxDisplayInstance.AddNumber(buttonInfo.buttonType);
    }

    public void OnSubtractButton(BaseEventData data)
    {
        DigitType buttonInfo = GetComponent<DigitType>();
        Mystery2MemoBoxDisplay.keyBoxDisplayInstance.SubtractNumber(buttonInfo.buttonType);
    }

    public void OnVerificationButton(BaseEventData data)
    {
        string displayPassword = Mystery2MemoBoxDisplay.keyBoxDisplayInstance.GetDisplayNumber();
        bool openFlag = Mystery2Manager.passwordInstance.Mystery2PasswordCompatison(displayPassword);

        if (openFlag)
        {
            Debug.Log("パスワードを解除しました");
            Mystery2BoxLidStateManagement.boxLidStateManagementInstance.OpenLid();
        }
    }
}
