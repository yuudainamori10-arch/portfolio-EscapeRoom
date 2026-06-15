using TMPro;
using UnityEngine;

public class EscapeKeyBoxDisplay : MonoBehaviour, IResetInterface
{
    public static EscapeKeyBoxDisplay keyBoxDisplayInstance;
    string defaultNumber = "0";
    [SerializeField] TextMeshPro firstDigit;
    [SerializeField] TextMeshPro secondDigit;
    [SerializeField] TextMeshPro thirdDigit;
    [SerializeField] TextMeshPro fourthDigit;
    int maxNum = 9;
    int minNum = 0;

    void Start()
    {
        firstDigit.text = defaultNumber;
        secondDigit.text = defaultNumber;
        thirdDigit.text = defaultNumber;
        fourthDigit.text = defaultNumber;
    }

    private void Awake()
    {
        if (keyBoxDisplayInstance is null)
        {
            keyBoxDisplayInstance = this;
        }
    }

    //箱に表示されるボタンの数字を増やす
    public void AddNumber(DigitType.Digit type)
    {
        switch (type)
        {
            case DigitType.Digit.FirstDigit:
                firstDigit.text = AddAction(int.Parse(firstDigit.text));
                    break;

            case DigitType.Digit.SecondDigit:
                secondDigit.text = AddAction(int.Parse(secondDigit.text));
                break;

            case DigitType.Digit.ThirdDigit:
                thirdDigit.text = AddAction(int.Parse(thirdDigit.text));
                break;

            case DigitType.Digit.FourthDigit:
                fourthDigit.text = AddAction(int.Parse(fourthDigit.text));
                break;
        }
    }

    private string AddAction(int number)
    {
        if (number == maxNum)
        {
            number = 0;
        }
        else
        {
            number++;
        }

        return number.ToString();
    }

    //箱に表示されるボタンの数字を減らす
    public void SubtractNumber(DigitType.Digit type)
    {
        switch (type)
        {
            case DigitType.Digit.FirstDigit:
                firstDigit.text = SubtractAction(int.Parse(firstDigit.text));
                break;

            case DigitType.Digit.SecondDigit:
                secondDigit.text = SubtractAction(int.Parse(secondDigit.text));
                break;

            case DigitType.Digit.ThirdDigit:
                thirdDigit.text = SubtractAction(int.Parse(thirdDigit.text));
                break;

            case DigitType.Digit.FourthDigit:
                fourthDigit.text = SubtractAction(int.Parse(fourthDigit.text));
                break;
        }
    }

    private string SubtractAction(int number)
    {
        if (number == minNum)
        {
            number = 9;
        }
        else
        {
            number--;
        }

        return number.ToString();
    }

    public string GetDisplayNumber()
    {
        string displayPassword = firstDigit.text + secondDigit.text + thirdDigit.text + fourthDigit.text;
        return displayPassword;
    }

    public void InitialzedObject()
    {
        firstDigit.text = defaultNumber;
        secondDigit.text = defaultNumber;
        thirdDigit.text = defaultNumber;
        fourthDigit.text = defaultNumber;
    }
}
