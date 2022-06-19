
using UnityEngine;

//蹦床代码
public class Trampoline : MonoBehaviour
{
    public float jumpForce;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("jump");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
        }
    }
    
}
