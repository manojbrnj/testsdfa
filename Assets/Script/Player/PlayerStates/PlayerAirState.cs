using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerStates
{
    public PlayerAirState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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

        if (player.IsWallCheck())
        {
            //   Debug.Log("Wall Mili");
            player.playerStateMachine.ChangeState(player.WallSlide);
        }
        if (xInput != 0)
        {
            //  rb.velocity = new Vector2();
            player.SetVelocity(player.moveSpeed * 0.5f * xInput, rb.velocity.y);
        }
        if (player.IsGroundCheck())
        {
            //   Debug.Log("Ground Mila");
            player.playerStateMachine.ChangeState(player.IdleState);
        }


    }
}
