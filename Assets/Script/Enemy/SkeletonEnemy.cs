using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonEnemy : Enemy
{
    public Enemy baseEnemy;
    public EnemyStateController enemyStateController;
    public EnemyIdleState IdleState;
    public EnemyWalkState WalkState;
    public EnemyBattleState BattleState;
    public EnemySkeletonAttack AttackState;

    protected override void Awake()
    {
        base.Awake();

        enemyStateController = new EnemyStateController();
    }

    protected override void Start()
    {
        base.Start();
   
        IdleState = new EnemyIdleState(baseEnemy, enemyStateController, "Idle", this);
        WalkState = new EnemyWalkState(baseEnemy, enemyStateController, "Walk", this);
        BattleState = new EnemyBattleState(baseEnemy, enemyStateController, "Walk", this);
        AttackState = new EnemySkeletonAttack(baseEnemy, enemyStateController, "Attack", this);
        enemyStateController.InitializeState(IdleState);
    }

    protected override void Update()
    {
        base.Update();
        enemyStateController._currentState.Update();

    }
    public virtual void AnimationTriggerFinish() => enemyStateController._currentState.AnimationTrigger();

  
}
