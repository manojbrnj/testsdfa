using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordThrowState : PlayerStates
{
    public PlayerSwordThrowState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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
        player.SetZeroVelocity();
        base.Update();
    }
}
