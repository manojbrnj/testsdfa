using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpstate : PlayerStates
{
    public PlayerJumpstate(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(rb.velocity.x * xInput, player.jumpForce);
    
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

       
        if (rb.velocity.y < 0)
        {
            playerStateMachine.ChangeState(player.AirState);
        }
        if (xInput != 0)
        {
            rb.velocity = new Vector2(player.moveSpeed  * xInput, rb.velocity.y);
        }

        if(xInput == 0)
        {
            player.SetZeroVelocity();
        }
    }
}
