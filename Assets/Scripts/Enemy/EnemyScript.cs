using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject enemy;
    private float timer;

    private void Awake()
    {
        enemy.SetActive(false);
        rb.position = new Vector2(-2, -1);
    }

    private void FixedUpdate()
    {
        timer += 50 * Time.deltaTime;
        Debug.Log(timer);
    }

    private void Update()
    {
        if (!CommonVar.inBed && !CommonVar.inShkaf && !CommonVar.inBath && timer > 10)
        {
            SceneManager.LoadScene("Looser");
        }

        if (timer > 0 && timer <= 80)
        {
            rb.linearVelocityX = -5f;
        }
        if (timer > 80 && timer <= 290)
        {
            rb.linearVelocityX = 5f;
        }
        if (timer > 290 && timer <= 400)
        {
            rb.linearVelocityX = -5f;
        }
        if (timer > 400)
        {
            CommonVar.inDanger = false;
            enemy.SetActive(false);
        }
    }
}