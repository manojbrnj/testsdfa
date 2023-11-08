using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates 
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected string animBoolName;
    public float xInput;
    public float yInput;
    protected Rigidbody2D rb;
    protected Animator anim;
    public bool trigger;

    public PlayerStates(Player _player,PlayerStateMachine _playerStateMachine,string _animBoolName)
    {
        this.player = _player;
        this.playerStateMachine = _playerStateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter() {
        trigger = false;
        rb = player.rb;
        anim = player.anim;
        anim.SetBool(animBoolName, true);

    }
    public virtual void Exit() {
        anim.SetBool(animBoolName, false);
    }
    public  virtual void Update() {
        xInput = Input.GetAxisRaw("Horizontal");        
        yInput = Input.GetAxisRaw("Vertical");    
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public virtual void AnimationTrigger()
    {
        trigger = true;
    }

}
