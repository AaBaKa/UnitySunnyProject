using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFour : MonoBehaviour
{
    public static LockFour instance;
    public bool isFourError;
    
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
        if (isFourError)
        {
            anim.SetBool("on",false);
            picture.SetActive(false);
            isFourError = false;
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
                isFourError = true;
                if (ListOn.instance.listLock.Count == 1)
                {
                    ListOn.instance.listLock.Clear();
                }
            }
            else
            {
                anim.SetBool("on",true);
                picture.SetActive(true);
            };
        }
    }
}
