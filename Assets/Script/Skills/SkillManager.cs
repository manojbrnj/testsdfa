using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public DashSkill dashskill;
    public CloneSkill cloneskill;
    public ThrowSwordSkill throwskill;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        dashskill = GetComponent<DashSkill>();
        cloneskill = GetComponent<CloneSkill>();
        throwskill = GetComponent<ThrowSwordSkill>();
    }


}
