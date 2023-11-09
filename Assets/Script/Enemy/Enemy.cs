using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Transform playerCheck;
    public float playerDistance;
    public LayerMask isPlayer;
  
    protected override void Awake()
    {
        base.Awake();
    
    }

    protected override void Start()
    {
        base.Start();
    
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
    }
}
