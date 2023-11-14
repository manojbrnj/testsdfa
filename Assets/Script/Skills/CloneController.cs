using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class CloneController : MonoBehaviour
{
    private SpriteRenderer sr;
    public Object particles;
    private GameObject par;
    public float alphaReduceRate;
    private float cloneVanishTimer;
    public float cloneVanishAfterDuration;
    private Animator animator;
    private GameObject closestEnemy;
    private float closestEnemyDistance = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        
      sr = GetComponentInChildren<SpriteRenderer>();
      animator = GetComponentInChildren<Animator>();
     // animator.SetInteger("CloneAttack", Random.Range(1, 4));
    }

    // Update is called once per frame
    void Update()
    {
        cloneVanishTimer -= Time.deltaTime;
        if (cloneVanishTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * alphaReduceRate));
            
        }
        if(sr.color.a <= 0)
        {
            if(par == null)
            {
                par = (GameObject)Instantiate(particles);
                par.transform.position = gameObject.transform.position;
            }
            Invoke("DestriyAll", 0.2f);

        }
    }
    public void SetupClone(Player t,bool _canAttack)
    {
        if (_canAttack)
        {
            animator.SetInteger("CloneAttack", Random.Range(1, 4));

        }
        cloneVanishTimer = cloneVanishAfterDuration;
        gameObject.transform.position= t.transform.position;
        FacingDirectionClone();
       // gameObject.transform.localScale = new Vector2(t.facingDir, 1);



    }
    public void DestriyAll()
    {
        Destroy(par);
        Destroy(gameObject);     



    }

    public void FacingDirectionClone()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 25.0f);


        foreach (var item in hit)
        {
          
            float itemDistance = Vector2.Distance(transform.position, item.transform.position);
            if(itemDistance < closestEnemyDistance && item.GetComponent<Enemy>() != null)
            {
                closestEnemyDistance = itemDistance;
                closestEnemy = item.gameObject;
                Debug.Log("skhdfkjshkjfhdskjfhjksd" + closestEnemy.name);
            }
        }
       

        if (closestEnemy.transform.position.x < PlayerManager.Instance.player.transform.position.x )
        {
            Debug.Log("skhdfkjshkjfhdskjfhjksd" + closestEnemy.name);
            transform.Rotate(0, -180, 0);
        }


    }
}
