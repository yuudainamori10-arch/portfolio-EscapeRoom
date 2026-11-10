using System;
using UnityEngine;

public class Mystery1Manager : MonoBehaviour, IResetInterface
{
    string correctPassword = string.Empty;
    public static Mystery1Manager passwordInstance;

    private void Awake()
    {
        if (passwordInstance is null)
        {
            passwordInstance = this;
        }
    }

    //ゲームを開始するたびにランダムなパスワードを作成する
    public void InitialzedObject()
    {
        var rnd = new System.Random();

        string firstDigit = rnd.Next(0, 9).ToString();
        string secondDigit = rnd.Next(0, 9).ToString();
        string thirdDigit = rnd.Next(0, 9).ToString();
        string fourthDigit = rnd.Next(0, 9).ToString();

        correctPassword = firstDigit + secondDigit + thirdDigit + fourthDigit;
        Debug.Log("Mystery1キーボックスのパスワード：" + correctPassword);
    }

    public bool PasswordCompatison(string userInputPassword)
    {
        if (correctPassword == userInputPassword)
        {
            return true;
        }

        return false;
    }
}