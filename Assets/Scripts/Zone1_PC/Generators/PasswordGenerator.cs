using UnityEngine;
using UnityEngine.UI;
using System;

public class PasswordGenerator : MonoBehaviour
{
    public static string CurrentPassword { get; private set; }
    public string Password { get; private set; }
    private bool wasCalled = false;
    private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [SerializeField] private Text PasswordText;

    public string GenPassword(int length = 12)
    {
        char[] Password = new char[length];

        for (int i = 0; i < length; i++)
        {
            Password[i] = CHARS[UnityEngine.Random.Range(0, CHARS.Length)];
        }

        return new string(Password);
    }

    public void ChangePasswordText()
    {
        if (wasCalled) return;

        Password = GenPassword();
        CurrentPassword = Password;
        PasswordText.text = Password;
        Debug.Log(Password);

        wasCalled = true;
    }

    public void CopyPassword()
    {
        GUIUtility.systemCopyBuffer = PasswordText.text;
    }
}
