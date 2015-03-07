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
    Attack,

}
public class FSMManagerPlayer : MonoBehaviour
{
    //   public bool isLocked = false;
    //   public PlayerStates savedStates;

    public FSMBase[] states;
    // FSMPlayerData d;
    public PlayerStates curState;
    public FSMPlayerData d;

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

    }
    void SetStates(PlayerStates newState)
    {

            curState = newState;
            foreach (FSMBase fb in states)
            {
                fb.enabled = false;
            }
            states[(int)curState].enabled = true;
            d.anim.SetInteger("curState", (int)curState);

    }
    void Move()
    {
        SetStates(PlayerStates.Move);
    }
    void ExtraMove()
    {

        if (d.bCanReceiveInput)
        {
          
            SetStates(PlayerStates.ExtraMove);
            d.bCanReceiveInput = false;
        }

    }
    void TurnLeft()
    {
        SetStates(PlayerStates.TurnLeft);
    }
    void ExtraTurnLeft()
    {
        if (d.bCanReceiveInput)
        {
            SetStates(PlayerStates.ExtraTurnLeft);
            d.bCanReceiveInput = false;
        }

    }
    void TurnRight()
    {
        SetStates(PlayerStates.TurnRight);
    }
    void ExtraTurnRight()
    {
        if (d.bCanReceiveInput)
        {
            SetStates(PlayerStates.ExtraTurnRight);
            d.bCanReceiveInput = false;
        }

    }
    void Idle()
    {
        SetStates(PlayerStates.Idle);
    }
    void Attack()
    {
    /*    if (d.bCanReceiveInput)
        {
            SetStates(PlayerStates.Attack);
            d.bCanReceiveInput = false;
        }*/
    }
}
