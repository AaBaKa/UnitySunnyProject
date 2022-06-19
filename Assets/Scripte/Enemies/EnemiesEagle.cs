
using UnityEngine;

public class EnemiesEagle : Enemies
{
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    public Transform UpPoint, DownPoint;
    public float flySpeed;

    private float upy,downy;
    private bool flyDown = true;
    
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        upy = UpPoint.position.y;
        downy = DownPoint.position.y;
        Destroy(UpPoint.gameObject);
        Destroy(DownPoint.gameObject);
    }
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (flyDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, -flySpeed);
        }
        
        if (transform.position.y > upy)
        {
            flyDown = true;
        }

        if (transform.position.y < downy)
        {
            rb.velocity = new Vector2(rb.velocity.x, flySpeed);
            flyDown = false;
        }
    }
}
