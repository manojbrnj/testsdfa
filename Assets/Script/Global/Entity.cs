using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    public Animator anim;

    [Header("Attack Details")]
    public Transform attackCheck;
    public float attackRadius;

    [Header("GroundCheck")]
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform groundCheck;
   [SerializeField] protected LayerMask isGroundLayer;

    [Header("WallCheck")]
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected Transform wallCheck;
    //[SerializeField] protected LayerMask isGroundLayer;

    [Header("MOVE CHARACTER")]
    public float moveSpeed;
    public float jumpForce;

    [Header("FlipCharacter Details FacingDir 1 and FacingRight True Wall Check kaam karne lagega")]
    public float facingDir;
    public bool facingRight;

    protected virtual void Awake()
    {
      
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x,groundCheck.position.y - groundCheckDistance));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y ));
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCheck.position,attackRadius);

    }

    public bool IsGroundCheck() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance,isGroundLayer);
    public bool IsWallCheck() => Physics2D.Raycast(wallCheck.position, new Vector2(wallCheck.position.x * facingDir,wallCheck.position.y), wallCheckDistance,isGroundLayer);
    public void SetVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x, rb.velocity.y );
        FlipController(x);
    }

    public void SetZeroVelocity()
    {
        rb.velocity = Vector2.zero;
       
    }

    public void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x)
    {
        if(x < 0 && facingRight)
        {
            Flip();
        }

       else if(x > 0 && !facingRight)
        {
            Flip();
        }
    }

    public virtual void Damage()
    {
        Debug.Log(gameObject.name + "Damaged");
    }
}
