using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : PlayerStates
{
    private float wallFacing;
    public PlayerWallJump(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        wallFacing = player.facingDir;
        player.wallJumpTimer = player.wallJumpLifeSpan;
        rb.velocity = new Vector2 (player.jump.x * -wallFacing,player.jump.y);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.wallJumpTimer < 0)
        {
            player.playerStateMachine.ChangeState(player.AirState);
        }
    }
}
