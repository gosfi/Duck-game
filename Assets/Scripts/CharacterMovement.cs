using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerId;
    [SerializeField] float moveSpeed;
    private Player player;
    private CharacterController cc;
    private Vector3 moveVector;
    private bool attack;
    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ProcessInput();
    }

    private void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.z = player.GetAxis("Move Vertical");
        attack = player.GetButtonDown("Attack");
    }

    private void ProcessInput()
    {
        if (moveVector.x != 0.0 || moveVector.z != 0.0)
        {
            cc.Move(moveVector * moveSpeed * Time.deltaTime);
        }

        if(attack)
        {
            Debug.Log("Attack got pressed");
        }
    }
}
