using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThrowSwordSkill : Skill
{

    public GameObject SwordPref;
    protected Player player;
    protected SwordController controller;
    public float swordThrowForce;
    public float gravityScale;
    public Vector2 direction;

    [Header("Create aim trail")]
    public GameObject dotPref;
    public GameObject[] dots;
    public int dotslength;
    public Transform dotPosStart;
    public Transform dotParent;
    public float distanceBetweenPoints;


    public override void UseSkill()
    {
        base.UseSkill();
    }

    protected override void Start()
    {
        base.Start();
        player = PlayerManager.Instance.player;
        dots = new GameObject[dotslength];

        for (int i = 0; i < dotslength; i++)
        {
            dots[i] = Instantiate(dotPref,player.transform.position,transform.rotation,dotParent);
            dots[i].SetActive(false);
        }
      
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("Hi");
            for (int i = 0; i < dots.Length; i++)
            {
                GeneratePoints( i,  i * distanceBetweenPoints);
            }
        }
        else
        {
            for (int i = 0; i < dotslength; i++)
            {
               
                dots[i].SetActive(false);
            }
        }

    }
    public Vector2 calculateDirection()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousepos - (Vector2) player.transform.position;
        return direction;
    }
    public void CreateSword()
    {

        GameObject newSwordPref = Instantiate(SwordPref,new Vector2(player.transform.position.x,player.transform.position.y),transform.rotation);
        controller = newSwordPref.GetComponent<SwordController>();
        controller.SetupSword(new Vector2(calculateDirection().normalized.x * swordThrowForce, calculateDirection().normalized.y * swordThrowForce), gravityScale);
        player.AssignSword(newSwordPref);
    }

    public void GeneratePoints(int i,float t)
    {
                  
            dots[i].transform.position = (Vector2)player.transform.position + new Vector2(calculateDirection().normalized.x * swordThrowForce, calculateDirection().normalized.y * swordThrowForce) * t + 0.5f * (Physics2D.gravity *gravityScale) *  (t * t);
            dots[i].SetActive(true);
        

    }
}
