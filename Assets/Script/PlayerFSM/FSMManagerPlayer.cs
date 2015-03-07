﻿using UnityEngine;
using System.Collections;
public enum PlayerStates : int
{
    Idle = 0,
    Move,
    ExtraMove,
    TurnLeft,
    ExtraTurnLeft,
    TurnRight,
    ExtraTurnRight,

}
public class FSMManagerPlayer : MonoBehaviour
{
    //   public bool isLocked = false;
    //   public PlayerStates savedStates;

    public FSMBase[] states;
    // FSMPlayerData d;
    public PlayerStates curState;
    public FSMPlayerData d;

   // public bool bCanReceiveInput = true;
    // bool _NeedSetStateIdle;
    // Use this for initialization
    void Awake()
    {
        states = GetComponents<FSMBase>();
        d = GetComponent<FSMPlayerData>();
        //d.anim = GetComponentInChildren<Animator>();
        // _NeedSetStateIdle = true;
        SetStates(PlayerStates.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        //       if (!isLocked)
        //       {
        //           SetStates(savedStates);
        //       }
    }
    void SetStates(PlayerStates newState)
    {

  //      if(newState == PlayerStates.Idle)
   //         bCanReceiveInput = true;
        
           // Debug.Log(newState);
            curState = newState;
            foreach (FSMBase fb in states)
            {
                fb.enabled = false;
            }
            states[(int)curState].enabled = true;
            d.anim.SetInteger("curState", (int)curState);
      
        //     if (newState != PlayerStates.Idle && curState == newState)
        //           return;

        //      if(!isLocked)
        //       {
       
        //       }
        //      else
        //       {
        //           savedStates = newState;
        //       }

    }
    void Move()
    {
        //       isLocked = true;
        SetStates(PlayerStates.Move);
    }
    void ExtraMove()
    {
        //       isLocked = true;

        if (d.bCanReceiveInput)
        {
            
            SetStates(PlayerStates.ExtraMove);
            d.bCanReceiveInput = false;
        }

    }
    void TurnLeft()
    {
        //    Debug.Log("left");
        SetStates(PlayerStates.TurnLeft);
    }
    void ExtraTurnLeft()
    {
        //       isLocked = true;
        if (d.bCanReceiveInput)
        {
           // d.bCanReceiveInput = false;
            SetStates(PlayerStates.ExtraTurnLeft);
            d.bCanReceiveInput = false;
        }

    }
    void TurnRight()
    {
        //    Debug.Log("right");
        SetStates(PlayerStates.TurnRight);
    }
    void ExtraTurnRight()
    {
        //    Debug.Log("right");
        if (d.bCanReceiveInput)
        {
            //d.bCanReceiveInput = false;
            SetStates(PlayerStates.ExtraTurnRight);
            d.bCanReceiveInput = false;
        }

    }
    void Idle()
    {
        //_NeedSetStateIdle = true;
       
        SetStates(PlayerStates.Idle);
    }
}
