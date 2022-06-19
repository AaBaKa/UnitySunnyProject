using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryWalling : MonoBehaviour
{
    [Header("墙移动的点，速度")]
    public GameObject wallingMovePoint;
    public float speed;
    

    private void FixedUpdate()
    {
        if (ShellOn.instance.isOneShell && ShellOnTwo.instance.isTwoShell && ShellOnTree.instance.isTreeShell)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallingMovePoint.transform.position,
                speed * Time.deltaTime);
        }
    }
}
