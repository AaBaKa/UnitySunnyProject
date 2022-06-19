
using UnityEngine;

public class CrankRightBGOnFix : MonoBehaviour
{
    private Animator anim;       //Crank杠杆开关的动画器
    private bool open;           //用于只有在开关触发器范围内才能，打开或关闭开关
    
    private int Nub=0;
    
    public GameObject Fix;       //开启状态的火台
    public GameObject off;       //关闭状态的火台
    
    [Header("开关按钮")] 
    public GameObject ButtonOn;
    public GameObject ButtonOff;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FixMove();
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
    
    private void OnTriggerEnter2D(Collider2D other)
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
    
    public void ButtonFixOn()    //按钮事件
    {
        anim.SetBool("up",true);
        Fix.SetActive(true);
        off.SetActive(false);
    }
    
    public void ButtonFixOff()   //按钮事件
    {
        anim.SetBool("up",false);
        Fix.SetActive(false);
        off.SetActive(true);
            
    }
    
    void FixMove()
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
                Fix.SetActive(false);
                off.SetActive(true);
                Nub = 0;
                
            }else if (Nub > 0)
            {
                anim.SetBool("up",true);
                Fix.SetActive(true);
                off.SetActive(false);
            }
        }
    }
}
