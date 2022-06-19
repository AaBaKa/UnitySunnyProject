using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellOn : MonoBehaviour
{
    public static ShellOn instance;

    [Header("开关是否按下")] 
    public bool isOneShell;

    [Header("反弹力")]
    public float force;
    
    //按下按钮的动画
    private Animator anim;      //开关的动画

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    { 
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果进入触发器的是Player
        if (other.tag == "shell")
        {
            anim.SetBool("on",true);
            
                other.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1f,3.5f,0) * force,ForceMode2D.Impulse);
                isOneShell = true;

        }
    }
    
}
