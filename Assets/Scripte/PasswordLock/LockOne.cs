using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOne : MonoBehaviour
{
    public static LockOne instance;
    public bool isOneError;

    [Header("图标")] 
    public GameObject picture;
    
    private Animator anim;
    
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
        picture.SetActive(false);
    }
    
    void Update()
    {
        if (isOneError)
        {
            anim.SetBool("on",false);
            picture.SetActive(false);
            isOneError = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果进入触发器的是Player
        if (other.CompareTag("Player"))
        {
            if (!anim.GetBool("on"))   //如果是关闭状态的
            {
                ListOn.instance.listLock.Add(1);
                ListOn.instance.isAdd = true;
            }

            if (anim.GetBool("on"))
            {
                isOneError = true;
                if (ListOn.instance.listLock.Count == 1)
                {
                    ListOn.instance.listLock.Clear();
                }
            }
            else
            {
                anim.SetBool("on",true);
                picture.SetActive(true);
            }
        }
    }
}
