using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
   // public CloneSkill cloneSkill;

    protected override void Start()
    {
        base.Start();
        //  cloneSkill = GetComponent<CloneSkill>();

    }

    protected override void Update()
    {
        base.Update();
    }

    public override bool CanWeUseSkill()
    {
        return base.CanWeUseSkill();
    }

    public override void UseSkill()
    {
        base.UseSkill();
       
      //  cloneSkill.CreateClone();
        //PlayerManager.Instance.player.rb.velocity = new Vector2(PlayerManager.Instance.player.dashSpeed * PlayerManager.Instance.player.facingDir, 0);
    }
}
