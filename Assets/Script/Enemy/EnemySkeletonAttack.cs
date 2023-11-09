using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAttack : EnemyStates
{
    SkeletonEnemy enemy;
    public EnemySkeletonAttack(Enemy _enemyBase, EnemyStateController _enemyStateController, string _animBoolName, SkeletonEnemy _enemy) : base(_enemyBase, _enemyStateController, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
      //  Debug.Log("Attack State me hu");
        enemy.anim.SetBool(animBoolName, true);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool(animBoolName, false);

        Debug.Log("Attack se Bahar hua");
    }

    public override void Update()
    {
        base.Update();
        enemy.SetZeroVelocity();
        if (trigger)
        {
            enemyStateController.ChangeState(enemy.BattleState);
        }
    }
}
