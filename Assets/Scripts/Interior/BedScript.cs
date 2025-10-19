using Common;
using UnityEngine;

public class BedScript : MonoBehaviour, IInteractable
{
    public Rigidbody2D rb;
    public CapsuleCollider2D cl;
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
        if (hit && !CommonVar.inBed)
        {
            cl.enabled = false; 
            rb.bodyType = RigidbodyType2D.Static;
            
            CommonVar.canMove = false;
            CommonVar.inBed = true;
            rb.position = new Vector2(-12f, -2.5f);
            timer = 0;
        }
        if (CommonVar.inBed && timer > 3)
        {
            cl.enabled = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            CommonVar.canMove = true;
            CommonVar.inBed = false;
            rb.position = new Vector2(-10, -0.8f);
        }
    }
}
