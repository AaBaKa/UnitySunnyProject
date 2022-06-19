using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassDoor : MonoBehaviour
{
    public GameObject compassDoor;
    public GameObject TheMoveGameObject;
    public float speed;
    
    private CompassIsOpen isOpen;
    private Vector3 startPoint;
    private Vector3 movePoint;
    void Start()
    { 
        isOpen = FindObjectOfType<CompassIsOpen>();
        startPoint = compassDoor.transform.position;
        movePoint = TheMoveGameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen.isOne  && isOpen.isTwo && isOpen.isTree)
        {
            compassDoor.transform.position =
                Vector3.MoveTowards(compassDoor.transform.position,movePoint , speed * Time.deltaTime);
        }
        else
        {
            compassDoor.transform.position =
                    Vector3.MoveTowards(compassDoor.transform.position, startPoint, speed* 3  * Time.deltaTime);
        }
    }
}
