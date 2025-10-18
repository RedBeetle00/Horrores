using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput; // Переменная для передачи кода из одного файла в другой
    public SpriteRenderer spriteRenderer;
    private float hori;
    
    // SerializeField означает, что несмотря на private, переменную можно будет менять из инспектора юнити
    [SerializeField] private float playerSpeed;

    public Animator animator;

    public Vector2 moveAmt; // Переменная для хранения вектора движения игрока

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // Получаем код из файла для ввода
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveAmt = PlayerInput.playerInputMove.ReadValue<Vector2>(); // Получаем вектор движения игрока из скрипта PlayerInput
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
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void Walking()
    {
        rb.linearVelocity = new Vector2(moveAmt.x * playerSpeed, rb.linearVelocity.y);
    }
}