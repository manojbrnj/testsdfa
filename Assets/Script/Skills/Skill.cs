using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private float skillTimer;

 //   [SerializeField] protected  float skillCoolDown;
    // Start is called before the first frame update
  protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        skillTimer -= Time.deltaTime;
    }

    public virtual bool CanWeUseSkill()
    {
        if(skillTimer < 0)
        {
            skillTimer = PlayerManager.Instance.player.dashCoolDown;
            UseSkill();
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual void UseSkill()
    {
       // PlayerManager.Instance.player.rb.velocity =  new Vector2(PlayerManager.Instance.player.dashSpeed * PlayerManager.Instance.player.facingDir, 0);
        Debug.Log("DashClone");

    }
}
