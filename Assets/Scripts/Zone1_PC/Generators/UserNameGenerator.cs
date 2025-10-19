using UnityEngine;
using UnityEngine.UI;
using System;

public class UserNameGenerator : MonoBehaviour
{
    private bool wasCalled = false;
    private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [SerializeField] private Text UserNameText;

    public string GenUsername(int length = 8)
    {
        char[] username = new char[length];

        for (int i = 0; i < length; i++)
        {
            username[i] = CHARS[UnityEngine.Random.Range(0, CHARS.Length)];
        }

        return new string(username);
    }

    public void ChangeUsernameText()
    {
        
        if (wasCalled) return;

        string username = GenUsername();
        UserNameText.text = username;
        Debug.Log(username);

        wasCalled = true;
    }

    public void CopyUsername()
    {
        GUIUtility.systemCopyBuffer = UserNameText.text;
    }
}
