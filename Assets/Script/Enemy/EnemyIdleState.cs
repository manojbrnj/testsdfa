using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyGroundedState
{

    public EnemyIdleState(Enemy _enemyBase, EnemyStateController _enemyStateController, string _animBoolName, SkeletonEnemy _enemy) : base(_enemyBase, _enemyStateController, _animBoolName,_enemy)
    {
    
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.SetBool(animBoolName, true);


        Debug.Log("Idle Enemy");
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool(animBoolName, false);
    }

    public override void Update()
    {
        base.Update();
        enemyStateController.ChangeState(enemy.WalkState);
    }
}
