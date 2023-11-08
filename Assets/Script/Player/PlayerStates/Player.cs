using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : Entity
{


    //Player Sates and Player Statemachine
    public PlayerStateMachine playerStateMachine;
    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerAirState AirState;
    public PlayerJumpstate JumpState;
    public PlayerWallSlide WallSlide;
    public PlayerWallJump WallJump;
    public PlayerDashState DashState;
    public PlayerAttackState AttackState;

    [Header("playerDash")]
    public float dashTimer;
    public float dashDuration;
    public float dashCoolDown;
    public float dashCoolDownTimer;
    public float dashSpeed;


    [Header("wall Jump")]
    public float wallJumpTimer;
    public float wallJumpLifeSpan;
    public float wallJumpCoolDown;
    public float wallJumpCoolDownTimer;

    [Header("ComboCounter")]
    public float comboTimer;
    public float comboTime;
    public float zeroveloforasecond;
    public Vector2[] attackMovement;

    public float lastTimesingleAttack;
    public Vector2 jump;

    protected override void Awake()
    {
        base.Awake();
        playerStateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, playerStateMachine, "Idle");
        MoveState = new PlayerMoveState(this, playerStateMachine, "Move");
        AirState = new PlayerAirState(this, playerStateMachine, "Jump");
        JumpState = new PlayerJumpstate(this, playerStateMachine, "Jump");
        WallSlide = new PlayerWallSlide(this, playerStateMachine, "Slide");
        WallJump = new PlayerWallJump(this, playerStateMachine, "Jump");
        DashState = new PlayerDashState(this, playerStateMachine, "Dash");
        AttackState = new PlayerAttackState(this, playerStateMachine, "Attack");
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerStateMachine.InitializeState(IdleState);

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        zeroveloforasecond -= Time.deltaTime;
        comboTimer -= Time.deltaTime;
        dashCoolDownTimer -= Time.deltaTime;
        dashTimer -= Time.deltaTime;
        wallJumpTimer -= Time.deltaTime;
        wallJumpCoolDownTimer -= Time.deltaTime;

        #region Dash
        if (Input.GetKeyDown(KeyCode.F) && dashCoolDownTimer < 0)
        {
            playerStateMachine.ChangeState(DashState);
            dashCoolDownTimer = dashCoolDown;
        }
        #endregion
        // Debug.Log(playerStateMachine._currentState);
        #region Attack
        if (Input.GetKeyDown(KeyCode.G) && playerStateMachine._currentState != AttackState) //&& comboTimer < 0
        {

            playerStateMachine.ChangeState(AttackState);
        }
        #endregion
        playerStateMachine._currentState.Update();
    }
    public void AnimationTrigger() => playerStateMachine._currentState.AnimationTrigger();
    //public bool busy;
    //public float busyTime;
    //public IEnumerator BusyFor(float time)
    //{
    //    busy = true;
    //    yield return new WaitForSeconds(time);
    //    busy = false;
    //}
}
