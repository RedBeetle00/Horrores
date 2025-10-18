using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}

