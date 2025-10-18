using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static InputAction playerInputMove;

    void Awake()
    {
        playerInputMove = InputSystem.actions.FindAction("Move");
    }
}