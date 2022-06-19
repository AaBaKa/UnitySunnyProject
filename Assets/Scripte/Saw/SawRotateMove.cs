using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotateMove : MonoBehaviour
{
    public GameObject onePoint;
    public GameObject twoPoint;
    public GameObject threePoint;
    public GameObject fourPoint;

    public float speed;
    
    private bool ones;
    private bool twos;
    private bool threes;
    private bool fours;
    
    void Start()
    {
        
    }

    void Update()
    {
        ThePointChance();
    }

    private void FixedUpdate()
    {
        if (ones)
        {
            transform.position = Vector3.MoveTowards(transform.position, twoPoint.transform.position, 
                speed * Time.deltaTime);
        }

        if (twos)
        {
            transform.position = Vector3.MoveTowards(transform.position, threePoint.transform.position, 
                speed * Time.deltaTime);
        }

        if (threes)
        {
            transform.position = Vector3.MoveTowards(transform.position, fourPoint.transform.position, 
                speed * Time.deltaTime);
        }

        if (fours)
        {
            transform.position = Vector3.MoveTowards(transform.position, onePoint.transform.position, 
                speed * Time.deltaTime);
        }
    }

    private void ThePointChance()
    {
        if (transform.position == onePoint.transform.position)
        {
            ones = true;
            twos = false;
            threes = false;
            fours = false;
        }

        if (transform.position == twoPoint.transform.position)
        {
            ones = false;
            twos = true;
            threes = false;
            fours = false;
        }

        if (transform.position == threePoint.transform.position)
        {
            ones = false;
            twos = false;
            threes = true;
            fours = false;
        }

        if (transform.position == fourPoint.transform.position)
        {
            ones = false;
            twos = false;
            threes = false;
            fours = true;
        }
    }
}
