using UnityEngine;
using UnityEngine.InputSystem;

public class ClickMover : MonoBehaviour
{
    public float stepSize = 1f;
    [SerializeField] private InputAction moveUp = new InputAction(type: InputActionType.Button); // Up arrow key
    [SerializeField] private InputAction moveDown = new InputAction(type: InputActionType.Button); // Down arrow key
    [SerializeField] private InputAction moveLeft = new InputAction(type: InputActionType.Button); // Left arrow key
    [SerializeField] private InputAction moveRight = new InputAction(type: InputActionType.Button); // Right arrow key

    // Initialize input actions
    void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable();
    }

    // Disable input actions
    void OnDisable()
    {
        moveUp.Disable();
        moveDown.Disable();
        moveLeft.Disable();
        moveRight.Disable();
    }

    void Update()
    {
        if (moveUp.WasPerformedThisFrame())
        {
            transform.position += new Vector3(0, stepSize, 0); // Move up
        }
        else if (moveDown.WasPerformedThisFrame())
        {
            transform.position += new Vector3(0, -stepSize, 0); // Move down
        }
        else if (moveLeft.WasPerformedThisFrame())
        {
            transform.position += new Vector3(-stepSize, 0, 0); // Move left
        }
        else if (moveRight.WasPerformedThisFrame())
        {
            transform.position += new Vector3(stepSize, 0, 0); // Move right
        }
    }
}