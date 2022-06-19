using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEight : MonoBehaviour
{
    public static LockEight instance;
    public bool isEightError;
    
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
    
    void Update()
    {
        if (isEightError)
        {
            anim.SetBool("on",false);
            picture.SetActive(false);
            isEightError = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果进入触发器的是Player
        if (other.CompareTag("Player"))
        {
            if (!anim.GetBool("on"))
            {
                ListOn.instance.listLock.Add(2);
                ListOn.instance.isAdd = true;
            }
            
            if (anim.GetBool("on"))
            {
                isEightError = true;
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
