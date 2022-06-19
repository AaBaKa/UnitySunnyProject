
using UnityEngine;

public class EnemiesNinjaFrog : Enemies
{
    private Rigidbody2D rb;
    private Animator anim;

    public Transform Left, Right;
    public float Speed;
    
    private float leftx, rightx;
    private bool Faceright = true; 
    
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftx = Left.position.x;
        rightx = Right.position.x;
        Destroy(Left.gameObject);
        Destroy(Right.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Faceright)
        {
            anim.SetBool("run",true);
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceright = false;
            }
        }else
        {
            anim.SetBool("run",true);
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }

        if (transform.position.x < leftx)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Faceright = true;
        }
    }
}
