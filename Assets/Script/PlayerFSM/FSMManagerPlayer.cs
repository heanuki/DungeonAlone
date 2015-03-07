using UnityEngine;
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
   // bool _NeedSetStateIdle;
	// Use this for initialization
	void Awake()
    {
        states = GetComponents<FSMBase>();
       // _NeedSetStateIdle = true;
        SetStates(PlayerStates.Idle);
    }
	
	// Update is called once per frame
	void Update () 
    {
 //       if (!isLocked)
 //       {
 //           SetStates(savedStates);
 //       }
	}
    void SetStates(PlayerStates newState)
    {
   //     if (newState != PlayerStates.Idle && curState == newState)
 //           return;

  //      if(!isLocked)
 //       {
        Debug.Log(newState);
            curState = newState;
            foreach (FSMBase fb in states)
            {
                fb.enabled = false;
            }
            states[(int)curState].enabled = true;
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
        SetStates(PlayerStates.ExtraMove);
    }
    void TurnLeft()
    {
    //    Debug.Log("left");
        SetStates(PlayerStates.TurnLeft);
    }
    void ExtraTurnLeft()
    {
        //       isLocked = true;
        SetStates(PlayerStates.ExtraTurnLeft);
    }
    void TurnRight()
    {
    //    Debug.Log("right");
        SetStates(PlayerStates.TurnRight);
    }
    void ExtraTurnRight()
    {
        //    Debug.Log("right");
        SetStates(PlayerStates.ExtraTurnRight);
    }
    void Idle()
    {
        //_NeedSetStateIdle = true;
        SetStates(PlayerStates.Idle);
    }
}
