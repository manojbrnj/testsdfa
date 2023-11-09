using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerStates
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        
     
       if(xInput != 0 && player.IsGroundCheck())
        {
            player.playerStateMachine.ChangeState(player.MoveState);
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundCheck())
        {
            player.playerStateMachine.ChangeState(player.JumpState);
        }
        if (xInput == 0)
        {
            player.playerStateMachine.ChangeState(player.IdleState);
        }
        if (xInput == player.facingDir && player.IsWallCheck() && player.IsGroundCheck())
        {
            player.playerStateMachine.ChangeState(player.IdleState);
        }
        else if (!player.IsGroundCheck() && !player.IsWallCheck())
        {
            player.playerStateMachine.ChangeState(player.AirState);
        }
        else if (!player.IsGroundCheck() && player.IsWallCheck())
        {
            player.playerStateMachine.ChangeState(player.AirState);
        }
    }
}
