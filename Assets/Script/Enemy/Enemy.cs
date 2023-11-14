using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Transform playerCheck;
    public float playerDistance;
    public LayerMask isPlayer;
    public EntityFx fx;

    [Header("StunState")]
    public float stunDuration;
    public float stunKnockBack;
    public bool canEnemyStun;
    public GameObject attackStunWindow;



    protected override void Awake()
    {
        base.Awake();
    
    }

    protected override void Start()
    {
        base.Start();
        fx = GetComponent<EntityFx>();
    
    }

    protected override void Update()
    {
        base.Update();
    
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerCheck.position, new Vector2(playerCheck.position.x + playerDistance * facingDir, playerCheck.position.y));

    }

       
    public RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(playerCheck.position,new Vector2(facingDir,0),playerDistance,isPlayer);

    public override void Damage()
    {
        base.Damage();
        StartCoroutine(fx.FlashFx());
    }
    public virtual void StunEnemy()
    {
        canEnemyStun = true;
        attackStunWindow.SetActive(true);
    }
    public virtual void StunEnemyFinish()
    {
        canEnemyStun = false;
        attackStunWindow.SetActive(false);
    }

    public virtual bool CanBeStunned()
    {
        if (canEnemyStun)
        {
           canEnemyStun = false;
            StunEnemyFinish();
            return true;
        }
        else
        {
            return false;
        }
    }
}
