using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput; // Переменная для передачи кода из одного файла в другой
    private CheckGround checkGround;
    
    // SerializeField означает, что несмотря на private, переменную можно будет менять из инспектора юнити
    [SerializeField] private float playerSpeed; 
    [SerializeField] private float jumpStrengh;

    public Vector2 moveAmt; // Переменная для хранения вектора движения игрока

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // Получаем код из файла для ввода
        checkGround = GetComponentInChildren<CheckGround>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveAmt = PlayerInput.playerInputMove.ReadValue<Vector2>(); // Получаем вектор движения игрока из скрипта PlayerInput

        if (PlayerInput.playerInputJump.WasPressedThisFrame() && checkGround.isGrounded)
        {
            Jump();
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

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpStrengh, ForceMode2D.Impulse);
    }
}