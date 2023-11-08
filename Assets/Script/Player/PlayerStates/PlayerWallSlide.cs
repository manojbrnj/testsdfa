using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlide : PlayerStates
{
    public float wallFacing;
    // Start is called before the first frame update
    public PlayerWallSlide(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        wallFacing = player.facingDir;
        base.Enter();
//Debug.Log("wall Slide me aaya hu");
    }

    public override void Exit()
    {
        base.Exit();
        player.Flip();
    }

    public override void Update()
    {
        base.Update();
       // Debug.Log("from wallSlide state " + xInput);
      if(xInput != 0 && xInput != player.facingDir)
        {

            playerStateMachine.ChangeState(player.IdleState);


        }
        if (player.IsGroundCheck())
        {
            player.playerStateMachine.ChangeState(player.IdleState);
        }
      if(yInput < 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
       
        }
        else
        {
            rb.velocity= new Vector2(0, rb.velocity.y * 0.8f) ;
        }

      if(Input.GetKeyDown(KeyCode.Space) && player.wallJumpCoolDownTimer < 0)
        {
            player.wallJumpCoolDownTimer = player.wallJumpCoolDown;
            player.playerStateMachine.ChangeState(player.WallJump);
            
        }
    }
}
