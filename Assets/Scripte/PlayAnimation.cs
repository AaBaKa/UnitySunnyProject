using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayControl player;
        
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayControl>();
    }

    
    void Update()
    {
        
    }
}
