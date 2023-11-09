using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates
{
    //public SkeletonEnemy enemy;
    public Enemy enemyBase;
    public bool trigger;
    public EnemyStateController enemyStateController;
    public string animBoolName;
    public EnemyStates(Enemy _enemyBase,EnemyStateController _enemyStateController,string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.enemyStateController = _enemyStateController;
        this.animBoolName = _animBoolName;
    }
    
    public virtual void Enter() {
     trigger = false;
    }
    public virtual void Exit() {
    
    }
    public virtual void Update() { }
    public virtual void AnimationTrigger ()
    { 
        trigger = true;
      //  Debug.Log("Trigger Hua");
    }

}
