using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttack : PlayerStates
{
    public PlayerCounterAttack(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        player.stateTimer = player.counterAttackDuration;
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackRadius);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.GetComponent<Enemy>() != null)
            {
                if (collider.gameObject.GetComponent<Enemy>().CanBeStunned())
                {
                    player.stateTimer = .2f;
                    player.anim.SetBool("SuccessfulCounterAttack", true);

                }
            }
           
        }
        if(player.stateTimer < 0 || trigger)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }
}
