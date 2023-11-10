using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunState : EnemyStates
{
    SkeletonEnemy enemy;
    private float stunTimer;
    private float facingDirStart;
    public EnemyStunState(Enemy _enemyBase, EnemyStateController _enemyStateController, string _animBoolName, SkeletonEnemy _enemy) : base(_enemyBase, _enemyStateController, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        facingDirStart = enemy.facingDir;
        stunTimer = enemy.stunDuration;
        enemy.anim.SetBool("Stun", true);
        enemy.SetVelocity(enemy.facingDir * -enemy.stunKnockBack, enemy.rb.velocity.y);
        enemy.fx.InvokeRepeating("Blinking", 0, .1f);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool("Stun", false);
        enemy.Flip();
        enemy.fx.Invoke("StopBlinking",0);
    }

    public override void Update()
    {
        base.Update();
        stunTimer -= Time.deltaTime;
        if(stunTimer < 0)
        {
            enemy.enemyStateController.ChangeState(enemy.IdleState);
        }
    }



   
}
