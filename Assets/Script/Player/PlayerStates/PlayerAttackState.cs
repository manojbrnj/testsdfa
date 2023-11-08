using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerStates
{
    private int counter;
    private float lastTimeAttack;

    public PlayerAttackState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
       
        base.Enter();

        Debug.Log(counter);
        player.zeroveloforasecond = .2f;
    
        if (counter > 2 || Time.time >= lastTimeAttack + player.comboTime)
        {
            counter = 0;
        }
        anim.SetInteger("Counter", counter);
   
    }

    public override void Exit()
    {
        base.Exit();
        counter++;
        lastTimeAttack = Time.time;
    }



    public override void Update()
    {

        if (player.zeroveloforasecond > 0)
        {
            //  player.SetZeroVelocity();
            rb.velocity = new Vector2(player.attackMovement[counter].x * player.facingDir, player.attackMovement[counter].y);
        }

        base.Update();

        if (trigger )
        {
            Debug.Log("StateChange");
            player.playerStateMachine.ChangeState(player.IdleState);
        }
    }
}
