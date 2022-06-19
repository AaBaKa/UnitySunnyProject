
using UnityEngine;

//注意：要想达到火消灭花的目的，就必须给花加上刚体
public class FlowerLightBG : Enemies
{
    
    private BoxCollider2D coll;
    protected override void Start()
    {
        base.Start();  //调用父类的start???
        coll = GetComponent<BoxCollider2D>();
    
    }
    
}
