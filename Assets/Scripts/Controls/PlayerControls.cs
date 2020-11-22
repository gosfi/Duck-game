using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    [Header("constant variables")]
    const float normalMoveSpeed = 10f;
    [Header("hidden variable")]
    Vector2 i_movement;
    bool turningLeft, turningRight, isSoundPlaying;
    [Header("Variable showing in the inspector")]
    [SerializeField] float moveSpeed = normalMoveSpeed;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] GameObject obj;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip AttackSound;

    #region UnityEvents
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

    public void OnAttack(CallbackContext context)
    {
        if (context.action.triggered)
        {
            Attack();
        }
        else
        {
            obj.SetActive(false);
        }
    }
    #endregion

    #region GameLogic
    void Update()
    {
        //always updating
        Move();
        //can't turn left and right at the same time
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
    private void Attack()
    {
        obj.SetActive(true);
        if (isSoundPlaying == false)
        {
            source.clip = AttackSound;
            StartCoroutine("PlayCoinCoinSound");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine("SlowPlayer");
        }
    }

    private IEnumerator SlowPlayer()
    {
        moveSpeed /= 2;
        yield return new WaitForSeconds(2);
        moveSpeed = normalMoveSpeed;
    }

    private IEnumerator PlayCoinCoinSound()
    {
        isSoundPlaying = true;
        source.Play();
        yield return new WaitForSeconds(AttackSound.length);
        isSoundPlaying = false;
    }
    #endregion
}
