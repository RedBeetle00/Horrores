using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}

