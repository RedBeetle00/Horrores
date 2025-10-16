using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Создаём переменные для ввода игрока из InputSystem
    public static InputAction playerInputMove;
    public static InputAction playerInputJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Получаем ввод игрока
        playerInputMove = InputSystem.actions.FindAction("Move");
        playerInputJump = InputSystem.actions.FindAction("Jump");
    }
}