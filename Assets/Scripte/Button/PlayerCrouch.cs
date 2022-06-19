using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCrouch : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public static PlayerCrouch instance;

    public bool isCrouch;
    
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
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isCrouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isCrouch = false;
    }
}
