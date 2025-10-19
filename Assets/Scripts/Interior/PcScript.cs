using UnityEngine;
using UnityEngine.SceneManagement;

public class PcScript : MonoBehaviour, IInteractable
{
    private bool hit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
    }

    public void Interact()
    {
        if (hit)
        {
            SceneManager.LoadScene("PcScene");
        }
    }
}