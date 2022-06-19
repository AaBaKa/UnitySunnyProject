
using System;
using UnityEngine;

public class Crank : MonoBehaviour
{
    private Animator anim;       //Crank杠杆开关的动画器
    private bool open;           //用于只有在开关触发器范围内才能，打开或关闭开关
    private bool sawUp;

    public float Speed;          //移动速度
    public Animator animSaw;     //滚动锯齿Saw的动画器
    public GameObject saw;      //滚动锯齿Saw的刚体

    [Header("滚轮移动的目标位置")] 
    public GameObject sawMovePoint;
    
    [Header("开关按钮")] 
    public GameObject ButtonOn;

    private bool sawMoveing;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        //OpenSaw();
    }

    private void FixedUpdate()
    {
        if (anim.GetBool("up"))
        {
            ButtonOn.SetActive(false);
        }

        if (sawMoveing)
        {
            SawMoveingOn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            open = true;
            if (!anim.GetBool("up"))
            {
                ButtonOn.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            open = false;
            ButtonOn.SetActive(false);
        }
    }

    void OpenSaw()      
    {
        if (open)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("up",true);
                animSaw.SetBool("SawOn",true);
                sawUp = true;
            }
        }

        if (sawUp)
        {
            //saw.velocity = new Vector2(-Speed, saw.velocity.y);
        }
    }

    public void CrankButton()    //按钮事件
    { 
        anim.SetBool("up", true);
        animSaw.SetBool("SawOn", true);

        sawMoveing = true;
    }

    private void SawMoveingOn()
    {
        saw.transform.position = Vector3.MoveTowards(saw.transform.position,sawMovePoint.transform.position,
            Speed * Time.deltaTime);
    }
}
