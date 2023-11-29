using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public Rigidbody2D rb;
    private Player player;
    private bool canRotate =true;
    // Start is called before the first frame update
    private void Awake()
    {
        player = PlayerManager.Instance.player;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    if(canRotate)
        {
            transform.right = rb.velocity;
        }
    }


    public void SetupSword(Vector2 _dir, float gm)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(_dir.x ,_dir.y);
            rb.gravityScale = gm;
        }

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

                canRotate = false;
               
                rb.isKinematic = true;   
        
          
               rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.SetParent(collision.gameObject.transform);
        circleCollider.enabled = false;
        //Destroy(gameObject);
        //player.sword = null;

    }
}
