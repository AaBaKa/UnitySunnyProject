using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyAppear : MonoBehaviour
{
    private GreyState _greyState;
    private GreyStateTwo _greyStateTwo;
    private GreyStateThree _greyStateThree;
    private GreyStateFour _greyStateFour;
    
    void Start()
    {
        _greyState = FindObjectOfType<GreyState>();
        _greyStateTwo = FindObjectOfType<GreyStateTwo>();
        _greyStateThree = FindObjectOfType<GreyStateThree>();
        _greyStateFour = FindObjectOfType<GreyStateFour>();
    }

    
    void FixedUpdate()
    {
        TheGreyState();
    }

    private void TheGreyState()
    {
        if (Time.time > _greyState.stateTime + _greyState.appearTime)
        {
            AppearGrey();
        }
        
        if (Time.time > _greyStateTwo.stateTime + _greyStateTwo.appearTime)
        {
            AppearGreyTwo();
        }
        
        if (Time.time > _greyStateThree.stateTime + _greyStateThree.appearTime)
        {
            AppearGreyThree();
        }
        
        if (Time.time > _greyStateFour.stateTime + _greyStateFour.appearTime)
        {
            AppearGreyFour();
        }
    }

    private void AppearGrey()
    {
        _greyState.gameObject.SetActive(true);
    }

    private void AppearGreyTwo()
    {
        _greyStateTwo.gameObject.SetActive(true);
    }

    private void AppearGreyThree()
    {
        _greyStateThree.gameObject.SetActive(true);
    }

    private void AppearGreyFour()
    {
        _greyStateFour.gameObject.SetActive(true);
    }
}
