using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    public PlayControl player;
    
    void Start()
    {
        instance = this;
    }
    
    void Update()
    {
        
    }
}
