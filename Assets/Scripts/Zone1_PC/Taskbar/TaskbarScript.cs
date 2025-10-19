using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskbarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public GameObject StartMenu;

    public void OpenCloseMenu()
    {
        StartMenu.SetActive(!StartMenu.activeSelf);
    }

    public void LeavePC()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}