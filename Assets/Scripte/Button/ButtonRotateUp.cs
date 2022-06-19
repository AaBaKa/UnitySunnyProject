using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonRotateUp : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isRotateUp;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (isRotateUp  && Turntable.instance.isTurn)
        {
            Turntable.instance.RotateButtonDown();    //炮台向上转
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isRotateUp = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRotateUp = false;
       Turntable.instance.chain.SetBool("chainOff",false);
    }
}
