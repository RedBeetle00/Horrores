using UnityEngine;
using UnityEngine.UI;

public class LOGIN_script : MonoBehaviour
{
    private string Password;
    private string Username;

    public InputField LogInFieldUsername;
    public InputField LogInFieldPassword;

    [SerializeField] public GameObject LogInSystem;
    [SerializeField] public GameObject HackingField;

    private static string CurrentPassword;
    private static string CurrentUserName;
    private static bool PasswordYN; // password yes or no
    private static bool UsernameYN; // username yes or no


    public void GetUsernameText()
    {
        CurrentUserName = LogInFieldUsername.text;
        //Debug.Log($"USERNAME: {CurrentUserName}");
    }

    public void GetPasswordText()
    {
        CurrentPassword = LogInFieldPassword.text;
        //Debug.Log($"PASSWORD: {CurrentPassword}");
    }

    public void Check()
    {
        Password = PasswordGenerator.CurrentPassword;
        Username = UserNameGenerator.CurrentUserName;

        PasswordYN = (CurrentPassword == Password);
        UsernameYN = (CurrentUserName == Username);

        if (UsernameYN && PasswordYN)
        {
            LogInSystem.SetActive(false);
            HackingField.SetActive(true);
        }
        else
        {
            Debug.Log($"Not cool. Username: {UsernameYN} username: {Username}, Password: {PasswordYN} password: {Password}");
        }
        Debug.Log($"TEST:USERNAME: {CurrentUserName}PASSWORD:{CurrentPassword}");
    }
}
