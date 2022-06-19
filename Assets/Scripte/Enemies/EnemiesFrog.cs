
using UnityEngine;

public class EnemiesFrog : Enemies
{
    private Rigidbody2D rb;
    //private Animator Anim;
    private CircleCollider2D Coll;

    public LayerMask Ground;
    public Transform leftPoint, rightPoint;

    public float Speed,JumpForce;     //速度
    private float leftx, rightx;

    private bool FaceLeft = true;       //面向的方向
    
    protected override void Start()
    {
        base.Start();  //调用父类的start
        rb = GetComponent<Rigidbody2D>();
        //Anim = GetComponent<Animator>();
        Coll = GetComponent<CircleCollider2D>();
        
        leftx = leftPoint.position.x;
        rightx = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SwicthAnim();
    }

    void Movement()
    {
        if (FaceLeft)
        {
            if (Coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jumping",true);
                rb.velocity = new Vector2(-Speed, JumpForce);
            }
            
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                FaceLeft = false;
            }
        }
        else
        {
            if (Coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jumping",true);
                rb.velocity = new Vector2(Speed, JumpForce);
            }
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                FaceLeft = true;
            }
        }
    }

    void SwicthAnim()
    {
        if (Anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                Anim.SetBool("jumping",false);
                Anim.SetBool("falling",true);
            }
        }
        
        if (Coll.IsTouchingLayers(Ground) && Anim.GetBool("falling"))
        {
            Anim.SetBool("falling",false);
        }
    }

    
}
