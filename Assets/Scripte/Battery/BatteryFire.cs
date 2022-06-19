using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryFire : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    
    [Header("列表,最大数量")] 
    public List<GameObject> _lists;
    public int nub;
    private int shellIndex = 0;
    
    [Header("炮弹,生成坐标,力")] 
    public GameObject shellPrefab;
    public GameObject isShellOpint;
    public float shellForce;

    [Header("是否靠近转盘")] 
    
    
    [Header("冷却时间")] 
    public float startTime;
    public float waitTime;

    public bool isShell;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //FireKeyOn();
    }

    private void FixedUpdate()
    {
        if (isShell && Time.time > startTime)
        {
            Fire();
            startTime = Time.time + waitTime;
        }
        
        ListShell();
    }

    private void FireKeyOn()
    {
        //开炮按钮
        if (Turntable.instance.isTurn && Input.GetKey(KeyCode.F))
        {
            isShell = true;
        }
        else
        {
            isShell = false;
        }
    }

    private void Fire()
    {
        
        anim.SetTrigger("batteryOn");
    }

    private void FireEvent()   //动画事件
    {
        var shell = Instantiate(shellPrefab, isShellOpint.transform.position, isShellOpint.transform.rotation);
            shell.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-1f,0,0) * shellForce,ForceMode2D.Impulse);
            _lists.Add(shell);
    }

    private void ListShell()
    {
        if (_lists.Count > nub)
        {
            Destroy(_lists[shellIndex]);
            _lists.RemoveAt(shellIndex);
        }
    }
}
