using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    #region Variables
    [Header("constant variables")]
    const float normalMoveSpeed = 10f;
    [Header("hidden variable")]
    Vector2 i_movement;
    AudioSource source;
    bool turningLeft, turningRight, isSoundPlaying, canAttack, isGameStarted;
    [Header("Variable showing in the inspector")]
    [SerializeField] float moveSpeed = normalMoveSpeed;
    [SerializeField] float turnSpeed = 50f;
    [SerializeField] GameObject obj;
    [SerializeField] AudioClip AttackSound;
    #endregion

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
        canAttack = context.action.triggered;
    }
    #endregion

    #region GameLogic

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        transform.position = new Vector3(0, 0.75f, 0);
    }
    void Update()
    {
        if (isGameStarted)
        {
            //always updating
            Move();
            Attack();
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
        if (canAttack)
        {
            obj.SetActive(true);
            if (isSoundPlaying == false)
            {
                source.clip = AttackSound;
                StartCoroutine("PlayCoinCoinSound");
            }
        }
        else
        {
            obj.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControls obj = other.GetComponent<PlayerControls>();
            StartCoroutine(SlowPlayer(obj));

        }
    }
    #region Couroutines
    private IEnumerator SlowPlayer(PlayerControls other)
    {
        other.moveSpeed /= 2;
        yield return new WaitForSeconds(4);
        other.moveSpeed = normalMoveSpeed;
    }
    private IEnumerator PlayCoinCoinSound()
    {
        isSoundPlaying = true;
        source.Play();
        yield return new WaitForSeconds(AttackSound.length);
        isSoundPlaying = false;
    }
    #endregion
    #endregion
}
