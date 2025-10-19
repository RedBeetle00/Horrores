using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class PcScript : MonoBehaviour, IInteractable
{
    public GameObject enemy;
    private bool hit;
    private float timer;

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
    private void FixedUpdate()
    {
        if (CommonVar.inDanger)
        {
            timer += 2 * Time.deltaTime;
            Debug.Log(timer);
            if (timer > 10)
            {
                ShowEnemy();
            }
        }
    }
    private void ShowEnemy()
    {
        enemy.SetActive(true);
    }
}