using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{

    public PlayerMoveState(Player _player, PlayerStateMachine _playerStatemachine, string _animBoolName) : base(_player, _playerStatemachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
         
        
    }

    public override void Exit()
    {
        base.Exit();
       // Debug.Log("MoveState se bahar");
        AudioManager.instance.walk.Stop();
        //AudioManager.instance.StopSfx("walk");
    }

    public override void Update()
    {
        base.Update();
      //  AudioManager.instance.PlayMusic("walk");
       // Debug.Log("MoveState me hu");
       

        player.SetVelocity(xInput * player.moveSpeed , rb.velocity.y);
      
        if(rb.velocity.x != 0)
        {
           // Debug.Log(rb.velocity.x);
            AudioManager.instance.PlaySfx("walk");
        }

    }
}
