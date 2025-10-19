using UnityEngine;
using Common;

public class ShkafScript : MonoBehaviour, IInteractable
{
    public Rigidbody2D rb;
    private bool shakvHit = false;
    private int timer;

    public void FixedUpdate()
    {
        timer += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shakvHit = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shakvHit = false;
    }

    public void Interact()
    {
        if (shakvHit && !CommonVar.inShkaf)
        {
            GoTusShkav();
            timer = 0;
        }
        if (CommonVar.inShkaf && timer > 3)
        {
            GoOutShkav();
        }
    }

    public void GoTusShkav()
    {
        CommonVar.canMove = false;
        CommonVar.inShkaf = true;
        rb.position = new Vector2(3f, -1f);
    }
    public void GoOutShkav()
    {
        CommonVar.canMove = true;
        CommonVar.inShkaf = false;
    }
}