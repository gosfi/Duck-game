using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerControls player;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var players = FindObjectsOfType<PlayerControls>();
        var index = playerInput.playerIndex;
        player = players.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }


    #region UnityEvents
    public void OnMove(CallbackContext context)
    {
        if(player != null)
        player.i_movement.y = context.ReadValue<float>();
    }

    public void OnTurnLeft(CallbackContext context)
    {
        if(player != null)
        player.turningLeft = context.action.triggered;
    }

    public void OnTurnRight(CallbackContext context)
    {
        if(player != null)
        player.turningRight = context.action.triggered;
    }

    public void OnAttack(CallbackContext context)
    {
        if(player != null)
        player.canAttack = context.action.triggered;
    }
    #endregion
}
