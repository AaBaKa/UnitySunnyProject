using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Camre;
    public float moveRate;

    private float statePointX, statePointY;
    [Header("勾选，y轴不移动")]
    public bool LockY;

    void Start()
    {
        statePointX = transform.position.x;
        statePointY = transform.position.y;
    }

    
    void Update()
    {
        if (LockY)
        {
            transform.position = new Vector2(statePointX + Camre.position.x * moveRate, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(statePointX + Camre.position.x * -moveRate, statePointY + Camre.position.y * moveRate * 0.5f);
        }
    }
}
