
using System;
using UnityEngine;

public class OfficeDoorOnOne : MonoBehaviour
{
    //这3个gameobject是三个墙壁
    public GameObject walling1;
    public GameObject walling2;
    public GameObject walling3;
    
    //按下按钮的动画
    private Animator anim;      //开关的动画

    //墙壁打开的速度
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
            //移动为-move，即打开1,2号门
            walling1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-move),ForceMode2D.Impulse);
            walling2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-move),ForceMode2D.Impulse);
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
