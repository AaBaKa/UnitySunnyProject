
using System;
using UnityEngine;

public class BulbLighter : MonoBehaviour
{
    private Animator anim;       //Crank杠杆开关的动画器
    private bool open;           //用于只有在开关触发器范围内才能，打开或关闭开关
    private int Nub=0;

    public GameObject light1;
    public GameObject Light2;
    public Animator bulbAnim;
    public Animator buleAnim2;
    
    [Header("开关按钮")] 
    public GameObject ButtonOn;
    public GameObject ButtonOff;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Bulb();
    }

    private void FixedUpdate()
    {
        if (open)
        {
            if (anim.GetBool("up"))
            {
                ButtonOff.SetActive(true);
                ButtonOn.SetActive(false);
            }
            else
            {
                ButtonOn.SetActive(true);
                ButtonOff.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            open = false;
            ButtonOn.SetActive(false);
            ButtonOff.SetActive(false);
        }
    }

    void Bulb()
    {
        if (open)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Nub++;
            }
            if (Nub > 1)
            {
                anim.SetBool("up",false);
                bulbAnim.SetBool("on",false);
                light1.SetActive(false);
                lightOff();
                Nub = 0;
                
            }else if (Nub > 0)
            {
                anim.SetBool("up",true);
                bulbAnim.SetBool("on",true);
                light1.SetActive(true);
                lightOn();
            }
        }
    }

    public void ButtonBulbOn()    //按钮事件
    {
        anim.SetBool("up",true);
        bulbAnim.SetBool("on",true);
        light1.SetActive(true);
        lightOn();
    }

    public void ButtonBulbOff()   //按钮事件
    {
        anim.SetBool("up",false);
        bulbAnim.SetBool("on",false);
        light1.SetActive(false);
        lightOff();
    }

    void lightOn()
    {
        buleAnim2.SetBool("on",true);
        Light2.SetActive(true);
    }
    
    void lightOff()
    {
        buleAnim2.SetBool("on",false);
        Light2.SetActive(false);
    }
}
