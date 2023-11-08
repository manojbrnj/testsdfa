using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWalkState : EnemyGroundedState
{
    
    public bool walk;
    public EnemyWalkState(Enemy _enemyBase, EnemyStateController _enemyStateController, string _animBoolName, SkeletonEnemy _enemy) : base(_enemyBase, _enemyStateController, _animBoolName,_enemy)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.anim.SetBool(animBoolName, true);
     
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool(animBoolName, false);


    }

    public override void Update()
    {
        base.Update();
        enemy.rb.velocity = new Vector2(enemy.moveSpeed * enemy.facingDir, 0);

        if (enemy.IsWallCheck())
        {
            enemy.Flip();
        }
        if (!enemy.IsGroundCheck())
        {
            enemy.Flip();
        }
      
       
    }

  
  
       
   
}
