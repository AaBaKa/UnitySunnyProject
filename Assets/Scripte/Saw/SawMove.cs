using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMove : MonoBehaviour
{
    public GameObject upPoint;
    public GameObject downPoint;

    public float speed;
    
    private Transform upMoveing;
    private Transform downMoveing;

    private bool up;
    private bool down;
    
    void Start()
    {
        upMoveing = upPoint.transform;
        downMoveing = downPoint.transform;
    }

    private void Update()
    {
        if (transform.position == upMoveing.position)
        {
            down = true;
            up = false;
        }

        if (transform.position == downMoveing.position)
        {
            up = true;
            down = false;
        }
    }

    void FixedUpdate()
    {
        if (down)
        {
            transform.position = Vector3.MoveTowards(transform.position, downMoveing.position, speed * Time.deltaTime);
        }

        if (up)
        {
            transform.position = Vector3.MoveTowards(transform.position, upMoveing.position, speed * Time.deltaTime);
        }
        
    }
}
