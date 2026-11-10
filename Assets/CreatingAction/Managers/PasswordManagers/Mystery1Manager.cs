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

        //Nextの上限は含まれないため10を指定して0～9にする
        string firstDigit = rnd.Next(0, 10).ToString();
        string secondDigit = rnd.Next(0, 10).ToString();
        string thirdDigit = rnd.Next(0, 10).ToString();
        string fourthDigit = rnd.Next(0, 10).ToString();

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

    //パスワードの指定した桁（0～3）の数字を返す
    public string GetDigit(int digitIndex)
    {
        return correctPassword[digitIndex].ToString();
    }
}