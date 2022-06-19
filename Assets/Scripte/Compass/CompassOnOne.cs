using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassOnOne : MonoBehaviour
{
    public GameObject compass01;
    public GameObject compass02;
    public GameObject compass03;

    public bool isOn;
    public float speed;


    public bool isCompassOne;
    public bool isCompassTwo;
    public bool isCompassTree;
    
    //按下按钮的动画
    private Animator anim;      //开关的动画
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        if (isOn)
        {
            if (isCompassOne)
            {
                compass03.transform.Rotate(new Vector3(0,0,10f) * speed * Time.deltaTime);
                compass02.transform.Rotate(new Vector3(0,0,10f) * speed * Time.deltaTime);
            }else if (isCompassTwo)
            {
                compass03.transform.Rotate(new Vector3(0,0,10f) * speed * Time.deltaTime);
                compass01.transform.Rotate(new Vector3(0,0,10f) * speed * Time.deltaTime);
            }else if (isCompassTree)
            {
                compass02.transform.Rotate(new Vector3(0,0,10f) * speed * Time.deltaTime);
            }
            
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果进入触发器的是Player
        if (other.tag == "Player")
        {
            isOn = true;
            anim.SetBool("on",true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isOn = false;
            anim.SetBool("on",false);
        }
    }
}
