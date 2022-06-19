
using System;
using UnityEngine;

public class OnFix : MonoBehaviour
{
    //打开的火焰的触发器代码，消灭敌人
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "敌人")
        {
            Enemies enemies = other.gameObject.GetComponent<Enemies>();
            enemies.Jumpon();
        }
    }
}
