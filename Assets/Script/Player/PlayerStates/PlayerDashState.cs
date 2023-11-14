using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerStates
{
    public PlayerDashState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.dashTimer = player.dashDuration;
       // player.SetVelocity(player.dashSpeed, rb.velocity.y);
        rb.velocity = new Vector2(player.dashSpeed * player.facingDir, 0);
        SkillManager.instance.cloneskill.CreateClone(player);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(player.dashTimer < 0)
        {
            if (!player.IsGroundCheck() && player.IsWallCheck())
            {
                player.playerStateMachine.ChangeState(player.AirState);
            }
            else
            {
                player.playerStateMachine.ChangeState(player.IdleState);
            }
           
        }

      
        
    }
}
