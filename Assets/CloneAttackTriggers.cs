using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneAttackTriggers : MonoBehaviour
{
    public Transform attackCheck;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, PlayerManager.Instance.player.attackRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.GetComponent<Enemy>())
            {
                collider.gameObject.GetComponent<Enemy>().Damage();
            }
        }
    }
}
