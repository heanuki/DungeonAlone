using UnityEngine;
using System.Collections;

public class FSMPlayerExtraTurnRight : FSMPlayer
{
 //   Vector3 rotateAxis = new Vector3(0f, 1f, 0f);
    Quaternion _endRot;
    //float _t;
   // public bool canRotate = true;
   // Vector3 rotateAxis = new Vector3(0f, 1f, 0f);
    void SetCanAction(bool bCanAction)
    {
        d.bCanReceiveInput = bCanAction;
    }
    void OnEnable()
    {
        //     float r = Quaternion.Angle(Quaternion.identity, transform.rotation);

        //      float tAngle = Mathf.Ceil(r / 90f) * 90f;
        //     _endRot = transform.rotation * Quaternion.Euler(Vector3.up * (tAngle - r));


        float r = Quaternion.Angle(Quaternion.identity, transform.rotation);
        if (d.bCanReceiveInput)
        {
            d.bCanReceiveInput = false;
            _endRot = transform.rotation * Quaternion.Euler(Vector3.up * 90f);
        }
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
            d.bCanReceiveInput = true;
            SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        }
        
	}
 
}
