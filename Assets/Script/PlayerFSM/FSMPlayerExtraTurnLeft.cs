﻿using UnityEngine;
using System.Collections;

public class FSMPlayerExtraTurnLeft : FSMPlayer
{

    Quaternion _endRot;

    void OnEnable()
    {
        float r = Quaternion.Angle(Quaternion.identity, transform.rotation);
       
        float tAngle = Mathf.Ceil(r / 90f) * 90f;
        Debug.Log("r = " + r + ", tAngle = " + tAngle);
        _endRot = transform.rotation * Quaternion.Euler(Vector3.up * -(tAngle - r));
       // Debug.Log("EnterExtraTurnLeft");
    }
    void OnDisable()
    {
       // Debug.Log("ExitExtraTurnLeft");
    }
	void Update ()
    {
        Quaternion nextRot = Quaternion.RotateTowards(
          transform.rotation, _endRot, d.rotateSpeed * Time.deltaTime);
        transform.rotation = nextRot;
        if (nextRot == _endRot)
        {
            SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        }
        
	}
 
}
