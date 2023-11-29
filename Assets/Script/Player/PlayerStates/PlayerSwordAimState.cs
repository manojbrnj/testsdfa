using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAimState : PlayerStates
{
    public PlayerSwordAimState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
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
        player.SetZeroVelocity();
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            //SkillManager.instance.throwskill.CreateSword();
            player.playerStateMachine.ChangeState(player.IdleState);
           
        }
    }
}
