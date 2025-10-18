using UnityEngine;
using Common;
using System.Runtime.CompilerServices;

public class BathScript : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CommonVar.isUse)
        {
            CommonVar.canMove = false;
            rb.position = new Vector2(14.25f, -0.15f);
            rb.linearVelocityY = 0f;
        }
    }
}