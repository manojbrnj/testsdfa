using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleState : EnemyStates
    
{
    SkeletonEnemy enemy;

    private Transform player;
    private float moveDir;
  
public EnemyBattleState(Enemy _enemyBase, EnemyStateController _enemyStateController, string _animBoolName, SkeletonEnemy _enemy) : base(_enemyBase, _enemyStateController, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
        enemy.anim.SetBool(animBoolName, true);
        Debug.Log("Battle");
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool(animBoolName, false);

    }

    public override void Update()
    {
        base.Update();
        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }
        enemy.SetVelocity(moveDir * enemy.moveSpeed, enemy.rb.velocity.y);

    }

   
}
