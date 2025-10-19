using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("OutPc");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}

