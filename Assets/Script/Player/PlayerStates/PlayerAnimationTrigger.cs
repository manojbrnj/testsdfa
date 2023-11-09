using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationTrigger()
    {
        player.AnimationTrigger();
    }


    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackRadius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.gameObject.GetComponent<Enemy>())
            {
                collider.gameObject.GetComponent<Enemy>().Damage();
            }
        }
    }
}
