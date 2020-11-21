using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    Vector2 i_movement;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnSpeed = 10f;
    bool turningLeft, turningRight;


    // Update is called once per frame
    void Update()
    {
        Move();
        if (turningLeft)
        {
            TurnLeft();
        }
        else if (turningRight)
        {
            TurnRight();
        }
    }

    private void Move()
    {
        Vector3 movement = new Vector3(0, 0, i_movement.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }

    public void OnMove(CallbackContext context)
    {
        i_movement.y = context.ReadValue<float>();
    }

    public void OnTurnLeft(CallbackContext context)
    {
        turningLeft = context.action.triggered;
    }

    public void OnTurnRight(CallbackContext context)
    {
        turningRight = context.action.triggered;
    }

    public void OnAttack()
    {
        Attack();
    }

    private void Attack()
    {
        Debug.Log("is attacking");
    }
}
