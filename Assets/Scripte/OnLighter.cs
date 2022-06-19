
using UnityEngine;

//火焰开关代码
public class OnLighter : MonoBehaviour
{
    public GameObject Fix;       //第一个开启状态的火台
    public GameObject off;       //第一个关闭状态的火台
    public GameObject Fix2;      //开启状态的火台
    public GameObject off2;     //关闭状态的火台
    public Collider2D idel;    //开关正常状态的碰撞器
    public Collider2D on;      //开关按下状态的碰撞器

    private Animator anim;      //开关的动画

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果进入触发器的是Player
        if (other.tag == "Player")
        {
            Fix.SetActive(true);
            Fix2.SetActive(true);
            off.SetActive(false);
            off2.SetActive(false);
            idel.enabled = false;
            on.enabled = true;
            anim.SetBool("on",true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Fix.SetActive(false);
            Fix2.SetActive(false);
            off.SetActive(true);
            off2.SetActive(true);
            idel.enabled = true;
            on.enabled = false;
            anim.SetBool("on",false);
        }
    }
}
