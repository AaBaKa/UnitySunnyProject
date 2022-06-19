using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRotateDown : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isRotateDown;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isRotateDown && Turntable.instance.isTurn)
        {
            Turntable.instance.RotateButtonUp();     //炮台向下转
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isRotateDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRotateDown = false;
        Turntable.instance.chain.SetBool("chainOn",false);
    }
}
