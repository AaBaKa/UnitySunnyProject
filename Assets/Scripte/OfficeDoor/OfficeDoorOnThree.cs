
using UnityEngine;

public class OfficeDoorOnThree : MonoBehaviour
{
    //这3个gameobject是三个墙壁
    public GameObject walling1;
    public GameObject walling2;
    public GameObject walling3;
    
    private Animator anim; 
    
    public float move;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果进入触发器的是Player
        if (other.tag == "Player")
        {
            //关闭1号门，打开3号门
            walling1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,move),ForceMode2D.Impulse);
            walling3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-move),ForceMode2D.Impulse);
            anim.SetBool("on",true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("on",false);
        }
    }
}
