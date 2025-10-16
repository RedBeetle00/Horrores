using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isGrounded {  get; private set; }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}