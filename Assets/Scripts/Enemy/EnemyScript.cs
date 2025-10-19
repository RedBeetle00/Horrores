using UnityEngine;
using Common;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject enemy;
    private float timer;

    private void Awake()
    {
        enemy.SetActive(false);
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
            Debug.Log("You Dead");
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
            enemy.SetActive(false);
        }
    }
}