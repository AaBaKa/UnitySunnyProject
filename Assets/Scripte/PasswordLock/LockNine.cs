using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockNine : MonoBehaviour
{
    public static LockNine instance;
    public bool isNineError;
    
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
    }
    
    private void FixedUpdate()
    {
        if (isNineError)
        {
            anim.SetBool("on",false);
            picture.SetActive(false);
            isNineError = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果进入触发器的是Player
        if (other.CompareTag("Player"))
        {
            if (!anim.GetBool("on"))
            {
                ListOn.instance.listLock.Add(3);
                ListOn.instance.isAdd = true;
            }
            
            if (anim.GetBool("on"))
            {
                isNineError = true;
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
