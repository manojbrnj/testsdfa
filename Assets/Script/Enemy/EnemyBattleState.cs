using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleState : EnemyStates
    
{
    SkeletonEnemy enemy;

    private Transform player;
    private float moveDir;
    private float battleTime;
  
public EnemyBattleState(Enemy _enemyBase, EnemyStateController _enemyStateController, string _animBoolName, SkeletonEnemy _enemy) : base(_enemyBase, _enemyStateController, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
        enemy.anim.SetBool(animBoolName, true);
        Debug.Log("Bettle me hu");
        battleTime = 3f;

    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool(animBoolName, false);
        Debug.Log("Bettle se bahar");
    }

    public override void Update()
    {
        base.Update();
        battleTime -= Time.deltaTime;
        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }
        if (enemy.IsPlayerDetected())
        {
            if (enemy.IsPlayerDetected().distance < enemy.playerDistance)
            {

                Debug.Log(enemy.IsPlayerDetected().distance);
                enemyStateController.ChangeState(enemy.AttackState);
            }
        }
        if(battleTime < 0 && !enemy.IsPlayerDetected())
        {
            enemyStateController.ChangeState(enemy.IdleState);
        }
        enemy.SetVelocity(moveDir * enemy.moveSpeed, enemy.rb.velocity.y);

    }

   
}
