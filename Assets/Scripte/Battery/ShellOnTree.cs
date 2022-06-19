using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellOnTree : MonoBehaviour
{
    public static ShellOnTree instance;

    //按下按钮的动画
    private Animator anim; //开关的动画

    [Header("反弹力")] public float force;
    
    [Header("开关是否按下")] public bool isTreeShell;

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
        if (other.CompareTag("shell"))
        {
            anim.SetBool("on", true);
            isTreeShell = true;
            
        }
    }
}
