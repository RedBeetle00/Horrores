using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static InputAction playerInputMove;
    public static InputAction playerInputJump;

    void Awake()
    {
        playerInputMove = InputSystem.actions.FindAction("Move");
        playerInputJump = InputSystem.actions.FindAction("Jump");
    }
}