using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyGroundedState : EnemyStates
{
    protected SkeletonEnemy enemy;


public EnemyGroundedState(Enemy _enemyBase, EnemyStateController _enemyStateController, string _animBoolName, SkeletonEnemy _enemy) : base(_enemyBase, _enemyStateController, _animBoolName)
    {
        this.enemy = _enemy;
    
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


        if (enemy.IsPlayerDetected())
        {
            enemy.enemyStateController.ChangeState(enemy.BattleState);
        }
     
    }

  
}
