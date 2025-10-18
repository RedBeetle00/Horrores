using UnityEngine;
using Common;
using System.ComponentModel.Design;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput; // Переменная для передачи кода из одного файла в другой
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private float hori;
    
    [SerializeField] private float playerSpeed;

    public Vector2 moveAmt;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // Получаем код из файла для ввода
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveAmt = PlayerInput.playerInputMove.ReadValue<Vector2>();
        
        hori = moveAmt.x;
        
        animator.SetFloat("Gori", Mathf.Abs(hori));
        if (moveAmt.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (moveAmt.x > 0)
        {
            spriteRenderer.flipX = false;
        }


        if (PlayerInput.playerInputUse.WasPressedThisFrame()/* && CommonVar.isUse == false*/)
        {
            CommonVar.isUse = true;
        }
        if (PlayerInput.playerInputUnUse.WasPressedThisFrame()/* && CommonVar.isUse == true*/)
        {
            CommonVar.isUse = false;
        }

        if (CommonVar.canMove)
        {
            spriteRenderer.enabled = true;
        }
        if (CommonVar.canMove == false && CommonVar.inShkaf)
        {
            spriteRenderer.enabled = false;
            stopPlayer();
        }
    }

    private void FixedUpdate()
    {
        if (CommonVar.canMove)
        {
            Walking();
        }
    }

    private void Walking()
    {
        rb.linearVelocity = new Vector2(moveAmt.x * playerSpeed, rb.linearVelocity.y);
    }

    private void stopPlayer()
    {
        rb.linearVelocityX = 0f;
    }
}