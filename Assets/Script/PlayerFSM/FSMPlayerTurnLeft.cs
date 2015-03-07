using UnityEngine;
using System.Collections;

public class FSMPlayerTurnLeft : FSMPlayer
{


  //  Vector3 rotateAxis = new Vector3(0f, 1f, 0f);
    Quaternion _endRot;
    void OnEnable()
    {
       // Debug.Log("EnterTurnLeft");
        _endRot = transform.rotation * Quaternion.Euler(Vector3.up * -90f);
    }
    void OnDisable()
    {
        //Debug.Log("ExitTurnLeft");
    }
	void Update ()
    {
        //transform.Rotate(rotateAxis, -d.rotateSpeed * Time.deltaTime);
        Quaternion nextRot = Quaternion.RotateTowards(
           transform.rotation, _endRot, d.rotateSpeed * Time.deltaTime);
        transform.rotation = nextRot;
        if(nextRot == _endRot)
        {
            _endRot = _endRot * Quaternion.Euler(Vector3.up * -90f);
        }
        

	}
 
}
