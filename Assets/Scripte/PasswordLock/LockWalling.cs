using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWalling : MonoBehaviour
{
    public Transform rotationMove;
    
    public float speed;
    
    void Start()
    {
    }
    
    private void FixedUpdate()
    {
        RotationMovement();
    }

    private void RotationMovement()
    {
        if (ListOn.instance.openWalling)
        {
            if (transform.eulerAngles.z < 89f)
            {
                transform.RotateAround(rotationMove.position,new Vector3(0,0,10f), speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.eulerAngles.z > 0.5)
            {
                transform.RotateAround(rotationMove.position,new Vector3(0,0,-10f),  speed * Time.deltaTime);
            }
        }
    }
}
