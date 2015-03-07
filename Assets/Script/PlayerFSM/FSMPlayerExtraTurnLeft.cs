using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FSMPlayerExtraTurnLeft : FSMPlayer
{

    Quaternion _endRot;
   // public bool canRotate = true;
    // Vector3 rotateAxis = new Vector3(0f, 1f, 0f);
    void SetCanAction(bool bCanAction)
    {
        //d.bCanReceiveInput = bCanAction;
    }
    void OnEnable()
    {
        //float r = Quaternion.Angle(Quaternion.identity, transform.rotation);
        if (d.bCanReceiveInput)
        {
       //     d.bCanReceiveInput = false;
            _endRot = transform.rotation * Quaternion.Euler(Vector3.up * -90f);
        }


    }
    void OnDisable()
    {
    }
    void Update()
    {

        Quaternion nextRot = Quaternion.RotateTowards(
          transform.rotation, _endRot, d.rotateSpeed * Time.deltaTime);

        transform.rotation = nextRot;
        if (nextRot == _endRot)
        {
           // d.bCanReceiveInput = true;
            SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        }

    }

}
