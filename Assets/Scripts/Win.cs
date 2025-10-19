using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
