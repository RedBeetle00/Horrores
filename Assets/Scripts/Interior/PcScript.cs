using UnityEngine;
using UnityEngine.SceneManagement;

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
        //timer += 10 * Time.deltaTime;
        //if (timer == 100)
        //{
            ShowEnemy();
        //}
    }
    private void ShowEnemy()
    {
        enemy.SetActive(true);
    }
}