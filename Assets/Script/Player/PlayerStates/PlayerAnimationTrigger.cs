using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player;
    private CinemachineImpulseSource Impulse;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        Impulse = GameObject.Find("CM vcam1").GetComponent<CinemachineImpulseSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FootStepStart()
    {
        AudioManager.instance.PlaySfx();
    }
    public void FootStepEnd()
    {
        AudioManager.instance.StopPlaySfx();
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


    public void IdleStateTrigger()
    {
       player.playerStateMachine.ChangeState(player.IdleState);
    }


    public void DisablePlayer()
    {
        player.enabled = false;
    }
    public void AnablePlayer()
    {
        player.enabled = true;
    }

    public void ThrowSword()
    {
        SkillManager.instance.throwskill.CreateSword();
    }


    public void ShakeScreen()
    {
        if(Impulse != null)
        {
            Impulse.GenerateImpulse();
            Debug.Log("Impulse");
        }
      
    }
}
