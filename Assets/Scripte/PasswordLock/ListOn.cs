using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ListOn : MonoBehaviour
{
    public static ListOn instance;

    [Header("按钮列表")] 
    public List<int> listLock;

    [Header("组合成的字符串")]
    public string result;

    [Header("避免一直更新的判断")] 
    public bool isAdd;

    [Header("密码错误判断")] 
    public bool passError;

    [Header("可能的密码顺序")] 
    public string passOne = "123123123";
    public string passTwo = "231231231";
    public string passTree = "312312312";

    [Header("开门判断")] 
    public bool openWalling;
    
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
        
    }
    
    void Update()
    {
        if (isAdd)
        {
            result = string.Join("",listLock);
            Debug.Log(result);
            if (listLock[0] == 1 && !Regex.IsMatch(passOne,result))
            {
                LockError();
                Debug.Log("一不成立");
                
            }else if (listLock[0] == 2 && !Regex.IsMatch(passTwo,result))
            {
                LockError();
                Debug.Log("二不成立");
                
            }else if (listLock[0] == 3 && !Regex.IsMatch(passTree,result))
            {
                LockError();
                Debug.Log("三不成立");
            }

            if (result == passOne || result == passTwo || result == passTree)
            {
                openWalling = true;
            }
            else
            {
                openWalling = false;
            }

            isAdd = false;
        }
        
    }

    private void LockError()
    {
        LockOne.instance.isOneError = true;
        LockTwo.instance.isTwoError = true;
        LockTree.instance.isTreeError = true;
        LockFour.instance.isFourError = true;
        LockFive.instance.isFiveError = true;
        LockSix.instance.isSixError = true;
        LockSeven.instance.isSevenError = true;
        LockEight.instance.isEightError = true;
        LockNine.instance.isNineError = true;
        listLock.Clear();
    }
}
