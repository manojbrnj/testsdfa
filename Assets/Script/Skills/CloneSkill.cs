using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill
{
    public Object clonePrefab;
    public GameObject cloneGameObject;
    public CloneController cloneController;
    [SerializeField] private bool canAttack;
    protected override void Start()
    {
        base.Start();
       
    }

    protected override void Update()
    {
        base.Update();
    }
    public void CreateClone(Player t)
    {


        cloneGameObject = (GameObject)Instantiate(clonePrefab);
        cloneController = cloneGameObject.GetComponent<CloneController>();
        //  cloneGameObject.transform.position = new Vector2(t.position.x, t.transform.position.y);
        //   cloneGameObject.transform.localScale = new Vector2(PlayerManager.Instance.player.facingDir, 1);
        cloneController.SetupClone(t, canAttack);
    }

  

    private void DestroyClone()
    {
    
        Destroy(cloneGameObject);
    }

}
