using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static InputAction playerInputMove;
    public static InputAction playerInputUse;
    public static InputAction playerInputUnUse;

    void Awake()
    {
        playerInputMove = InputSystem.actions.FindAction("Move");
        playerInputUse = InputSystem.actions.FindAction("Use");
        playerInputUnUse = InputSystem.actions.FindAction("UnUse");
    }
}