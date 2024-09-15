using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D movementP;
    [SerializeField] private float speed = 10f;
    private Vector2 movementInput;
    void Update()
    {
        Vector2 movement = movementInput * speed;
        movementP.velocity = movement;
    }
    public void movementDirection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            movementInput = Vector2.zero;
        }
    }
}