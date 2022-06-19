using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Turntable : MonoBehaviour
{
    public static Turntable instance;
    
    [Header("向下，向上旋转,炮弹按钮")]
    public bool isFronts;
    public bool isAfter;

    [Header("转盘,转盘旋转中心,旋转速度")] 
    public GameObject turntable;
    public GameObject mid;
    public float speed;

    [Header("炮台,旋转中心,旋转速度")] 
    public GameObject battery;
    public GameObject batteryMid;
    public float batterySpeed;

    [Header("链条")] 
    public Animator chain;

    [Header("是否接近")] 
    public bool isTurn;
    
    [Header("开关按钮")] 
    public GameObject RotateUp;
    public GameObject RotateDown;
    public GameObject BetteryFir;
    
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

    private void Update()
    {
        //ButtonKeyOn();
        if (isAfter)
        {
            RotateButtonDown();
        }
    }

    void FixedUpdate()
    {
        //TurntableOn();  //键盘操作

        RotateButtonFixEvent();
    }

    
    private void TurntableOn()      //转盘旋转
    {
        if (isFronts)
        {
            chain.SetBool("chainOn",true);
            turntable.transform.RotateAround(mid.transform.position,new Vector3(0,0,10f), speed * Time.deltaTime);
            BatteryRotateFront();
        }
    
        if (isAfter)
        {
            chain.SetBool("chainOff",true);
            turntable.transform.RotateAround(mid.transform.position,new Vector3(0,0,-10f), speed * Time.deltaTime);
            BatteryRotateAfter();    
        }
    }
    

    private void ButtonKeyOn()    //键盘操作按键获取
    {
        //向下旋转按钮
        if (isTurn && Input.GetKey(KeyCode.E))
        {
            isFronts = true;
            isAfter = false;
        }
        else
        {
            isFronts = false;
            chain.SetBool("chainOn",false);
        }
    
        //向上旋转按钮
        if (isTurn && Input.GetKey(KeyCode.Q))
        {
            isAfter = true;
            isFronts = false;
        }
        else
        {
            isAfter = false;
            chain.SetBool("chainOff",false);
        }
        
    }

    
    private void BatteryRotateFront()        //炮台旋转
    {
        //Debug.Log(battery.transform.eulerAngles.z);
        //改为83f，避免偏差导致转到最下面后，无法再向上转
        if (battery.transform.eulerAngles.z < 83f || battery.transform.eulerAngles.z > 275f)
        {
            battery.transform.RotateAround(batteryMid.transform.position,new Vector3(0,0,10f),batterySpeed * Time.deltaTime);
        }
    }

    private void BatteryRotateAfter()       //炮台旋转
    {
        //Debug.Log(battery.transform.eulerAngles.z);
        //改为277f，避免偏差导致转到最上面后，无法再向下转
        if (battery.transform.eulerAngles.z < 85f || battery.transform.eulerAngles.z > 277f)
        {
            battery.transform.RotateAround(batteryMid.transform.position,new Vector3(0,0,-10f),batterySpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTurn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTurn = false;
        }
    }

    private void RotateButtonFixEvent()    //手机操作按钮判断
    {
        if (isTurn)
        {
            RotateUp.SetActive(true);
            RotateDown.SetActive(true);
            BetteryFir.SetActive(true);
        }
        else
        {
            RotateUp.SetActive(false);
            RotateDown.SetActive(false);
            BetteryFir.SetActive(false);
        }
    }

    public void RotateButtonUp()     //炮台向下转转按钮事件
    {
        chain.SetBool("chainOn",true);
        turntable.transform.RotateAround(mid.transform.position,new Vector3(0,0,10f), speed * Time.deltaTime);
        BatteryRotateFront();
    }

    public void RotateButtonDown()     //炮台向上转转按钮事件
    {
        chain.SetBool("chainOff",true);
        turntable.transform.RotateAround(mid.transform.position,new Vector3(0,0,-10f), speed * Time.deltaTime);
        BatteryRotateAfter(); 
    }

}
