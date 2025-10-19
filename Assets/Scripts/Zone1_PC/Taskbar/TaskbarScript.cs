using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class TaskbarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public GameObject StartMenu;
    private float timer;
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenCloseMenu()
    {
        StartMenu.SetActive(!StartMenu.activeSelf);
    }

    public void LeavePC()
    {
        SceneManager.LoadScene("OutPC");
    }

    public void FixedUpdate()
    {
        if (CommonVar.inDanger)
        {
            timer += 2 * Time.deltaTime;
            Debug.Log(timer);
            if (timer > 10)
            {
                SceneManager.LoadScene("Looser");
            }
        }
    }
}