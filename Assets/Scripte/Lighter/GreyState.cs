using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyState : MonoBehaviour
{
    public float vanishTime;
    public float appearTime;

    public float stateTime;

    void Start()
    {
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Vanish());
        }
    }

    IEnumerator Vanish()
    {
        stateTime = Time.time;
        yield return new WaitForSeconds(vanishTime);
        gameObject.SetActive(false);
    }
}
