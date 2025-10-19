using UnityEngine;
using Common;

public class BathScript : MonoBehaviour, IInteractable
{
    public Rigidbody2D rb;
    private bool hit;
    private int timer;

    private void FixedUpdate()
    {
        timer += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
    }

    public void Interact()
    {
        if (hit && !CommonVar.inBath)
        {
            CommonVar.canMove = false;
            CommonVar.inBath = true;
            rb.position = new Vector2(14.25f, -0.15f);
            rb.linearVelocityX = 0f;
            timer = 0;
        }
        if (CommonVar.inBath && timer > 3)
        {
            CommonVar.canMove = true;
            CommonVar.inBath = false;
            rb.position = new Vector2(12.5f, -1f);
        }
    }
}