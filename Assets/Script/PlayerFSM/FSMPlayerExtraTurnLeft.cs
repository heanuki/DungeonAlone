using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FSMPlayerExtraTurnLeft : FSMPlayer
{

    Quaternion _endRot;
    public bool canRotate = true;
    // Vector3 rotateAxis = new Vector3(0f, 1f, 0f);
    void SetCanAction(bool bCanAction)
    {
        canRotate = bCanAction;
    }
    void OnEnable()
    {
        float r = Quaternion.Angle(Quaternion.identity, transform.rotation);
        if (canRotate)
        {
            canRotate = false;
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
            canRotate = true;
            SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        }

    }

}
