using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; // Переменная для физического тела
    private PlayerInput playerInput; // Переменная для передачи кода из одного файла в другой
    
    // SerializeField означает, что несмотря на private, переменную можно будет менять из инспектора юнити
    [SerializeField] private float playerSpeed; 
    [SerializeField] private float jumpStrengh;

    public Vector2 moveAmt; // Переменная для хранения вектора движения игрока

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // Получаем код из файла для ввода
        rb = GetComponent<Rigidbody2D>(); // Получаем Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        moveAmt = PlayerInput.playerInputMove.ReadValue<Vector2>(); // Получаем вектор движения игрока из скрипта PlayerInput

        if (PlayerInput.playerInputJump.WasPressedThisFrame()) // Если пробел был нажат, то...
        {
            Jump();
        }
    }

    // Обновляется каждые 50 (вроде, так сказал дипсик) кадров
    private void FixedUpdate()
    {
        Walking();
    }

    private void Walking()
    {
        rb.MovePosition(rb.position + Vector2.right * moveAmt.x * playerSpeed * Time.deltaTime); // Берём позицию игрока и прибавляем к ней вектор движения умноженный на скорость. Time.deltaTime делает так, что частота кадров не будет влиять на скорость перемещения
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpStrengh, ForceMode2D.Impulse); // Пытаюсь сделать прыжок, но эта хенря не работает
        Debug.Log("Jump"); // Выводит в консоль сообщение. Использую для проверки на то, что метов вообще срабатывает
    }
}