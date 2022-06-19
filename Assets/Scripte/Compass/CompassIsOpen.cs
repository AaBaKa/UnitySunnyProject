using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassIsOpen : MonoBehaviour
{
    public GameObject isOpen01;
    public GameObject isOpen02;
    public GameObject isOpen03;

    public bool isOne;
    public bool isTwo;
    public bool isTree;

    void Update()
    {
        IsOpenCompass();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("罗盘三层"))
        {
            isOne = true;
        }

        if (other.CompareTag("罗盘二层"))
        {
            isTwo = true;
        }

        if (other.CompareTag("罗盘一层"))
        {
            isTree = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("罗盘三层"))
        {
            isOne = false;
        }

        if (other.CompareTag("罗盘二层"))
        {
            isTwo = false;
        }

        if (other.CompareTag("罗盘一层"))
        {
            isTree = false;
        }
    }

    private void IsOpenCompass()
    {
        isOpen01.SetActive(isOne);
        isOpen02.SetActive(isTwo);
        isOpen03.SetActive(isTree);
    }
}
