using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonTrigger : MonoBehaviour
{
    private SkeletonEnemy enemy;

    void Start()
    {
        enemy = GetComponentInParent<SkeletonEnemy>();

    }
    private void AnimationTrigger()=>enemy.AnimationTriggerFinish();
    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.GetComponent<Player>())
            {
                collider.gameObject.GetComponent<Player>().Damage();
            }
        }
    }
}
