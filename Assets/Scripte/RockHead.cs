using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private PlayControl _play;

    private float _startTime;
    [Header("等待时间,上升数度,落重力")]
    public float _waitTime;
    public float speed;
    public float gravitys;

    [Header("尖刺石头")] 
    public bool isSpikeHead;
    
    private bool _isGroundHit;
    private Vector3 _originalPosition;

    private static readonly int IsBottomHit = Animator.StringToHash("isGround");      //将string转int,加快执行效率
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _play = FindObjectOfType<PlayControl>();
        _startTime = Time.time;
        _originalPosition = _rb.position;
    }

    private void FixedUpdate()
    {
        if (_isGroundHit)
        {
            if (Time.time > _startTime + _waitTime && transform.position != _originalPosition)
            {
                _rb.isKinematic = true;
                _rb.gravityScale = 1f;
                transform.position = Vector3.MoveTowards(transform.position, _originalPosition,
                    speed * Time.deltaTime);
            }else if (transform.position == _originalPosition)
            {
                _startTime = Time.time;
                _isGroundHit = false;
            }
        }
        else
        {
            if (Time.time > _startTime + _waitTime)
            {
                _rb.isKinematic = false;
                _rb.gravityScale = gravitys;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6 || other.gameObject.CompareTag("敌人"))
        {
            //_anim.SetTrigger(IsBottomHit);
            _startTime = Time.time;
            _isGroundHit = true;
            
        }

        if (isSpikeHead && other.gameObject.CompareTag("Player"))
        {
            _play.hurtAudio.Play();
            _play.isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && _rb.velocity.y < 0)
        {
            _play.hurtAudio.Play();
            _play.isDead = true;
        }
    }
}
