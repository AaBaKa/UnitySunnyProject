
using UnityEngine;

//上升平台代码
public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private bool sure;
    private float upy,downy;

    public Transform UpPoint;
    public float aboveSpeed,downSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        upy = UpPoint.position.y;
        Destroy(UpPoint.gameObject);
    }

    void Update()
    {
        AboveOrDown();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sure = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sure = false;
        }
    }

    void AboveOrDown()
    {
        if (sure)
        {
            if (transform.position.y < upy)
            {
                rb.velocity = new Vector2(rb.velocity.x, aboveSpeed);
                anim.SetBool("Up",true);
            }

        }else
        {
            rb.velocity = new Vector2(rb.velocity.x, -downSpeed);
            anim.SetBool("Up",false);
        }
    }
}
