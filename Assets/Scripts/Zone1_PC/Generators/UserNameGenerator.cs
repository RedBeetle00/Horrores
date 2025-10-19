using UnityEngine;
using UnityEngine.UI;
using System;

public class UserNameGenerator : MonoBehaviour
{
    public static string CurrentUserName { get; private set; }
    public string UserName { get; private set; }
    private bool wasCalled = false;
    private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [SerializeField] private Text UserNameText;

    public string GenUsername(int length = 8)
    {
        char[] UserName = new char[length];

        for (int i = 0; i < length; i++)
        {
            UserName[i] = CHARS[UnityEngine.Random.Range(0, CHARS.Length)];
        }

        return new string(UserName);
    }

    public void ChangeUsernameText()
    {

        if (wasCalled) return;

        string UserName = GenUsername();
        CurrentUserName = UserName;
        UserNameText.text = UserName;
        Debug.Log(UserName);

        wasCalled = true;
    }

    public void CopyUsername()
    {
        GUIUtility.systemCopyBuffer = UserNameText.text;
    }
}
