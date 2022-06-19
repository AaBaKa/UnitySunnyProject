
using UnityEngine;

public class EnemiesOpossum : Enemies
{
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    
    public Transform leftPoint, rightPoint;
    public float Speed;
    
    private float leftx, rightx;
    private bool FaceLeft = true; 
    
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        leftx = leftPoint.position.x;
        rightx = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (FaceLeft)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                FaceLeft = false;
            }
        }else
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }

        if (transform.position.x > rightx)
        {
            transform.localScale = new Vector3(1, 1, 1);
            FaceLeft = true;
        }

        
    }
}
