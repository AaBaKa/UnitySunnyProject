
using UnityEngine;

public class SawKill : MonoBehaviour
{
    //Saw滚动锯齿碰撞器代码，消灭敌人
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "敌人")
        {
            Enemies enemies = other.gameObject.GetComponent<Enemies>();
            enemies.Jumpon();
        }
    }
}
