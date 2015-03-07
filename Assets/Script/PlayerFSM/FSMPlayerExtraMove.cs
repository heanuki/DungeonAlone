﻿using UnityEngine;
using System.Collections;

public class FSMPlayerExtraMove : FSMPlayer
{

 //    Vector3 _forward;
     Vector3 _StartPos;
     Vector3 _EndPos;


    void OnEnable()
    {

       // Debug.Log("EnterExtraMove");
  //      _forward = transform.forward;
        _StartPos = transform.position;
        _EndPos = new Vector3((float)((int)_StartPos.x), transform.position.y, (float)((int)_StartPos.z)) + transform.forward;

    }
    void OnDisable()
    {
        //Debug.Log("ExitExtraMove");
    }
	void Update ()
    {
     /*   if (_EndPos - transform.forward == transform.position)
        {
            SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
            return;
        }*/
        Ray r = new Ray(_StartPos, _EndPos - _StartPos);
        RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, 1f))
        {
            if (hitInfo.collider.tag == "WALL")
                return;
            if (hitInfo.collider.tag == "DOOR")
            {
               // Debug.Log("Meet the wall|");
                return;
            }
        }
        Vector3 nextPos = Vector3.MoveTowards(transform.position, _EndPos, d.moveSpeed * Time.deltaTime);
       
        if (_EndPos == nextPos)
        {
            SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        }
        else
        {
            transform.position = nextPos;
        }
        //transform.position = Vector3.Lerp(_StartPos, _EndPos, _t * d.moveSpeed);

        //if (_t * d.moveSpeed > 1f)
        //{
        //    _t = 0f;
        //    SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        //}
	}
   
}
