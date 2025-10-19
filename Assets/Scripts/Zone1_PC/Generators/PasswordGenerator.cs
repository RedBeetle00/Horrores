using UnityEngine;
using UnityEngine.UI;
using System;

public class PasswordGenerator : MonoBehaviour
{
    private bool wasCalled = false;
    private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [SerializeField] private Text PasswordText;

    public string GenPassword(int length = 12)
    {
        char[] password = new char[length];

        for (int i = 0; i < length; i++)
        {
            password[i] = CHARS[UnityEngine.Random.Range(0, CHARS.Length)];
        }

        return new string(password);
    }

    public void ChangePasswordText()
    {
        
        if (wasCalled) return;

        string password = GenPassword();
        PasswordText.text = password;
        Debug.Log(password);

        wasCalled = true;
    }

    public void CopyPassword()
    {
        GUIUtility.systemCopyBuffer = PasswordText.text;
    }
}
