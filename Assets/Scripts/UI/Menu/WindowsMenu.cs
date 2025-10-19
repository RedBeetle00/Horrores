using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Looser");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}

