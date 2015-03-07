using UnityEngine;
using System.Collections;

public class FSMPlayerMove : FSMPlayer
{

     Vector3 _forward;
  //  public FSMManagerPlayer manager;

    float _t;
    void OnEnable()
    {
       
        Debug.Log("EnterMove");
        _forward = transform.forward;
 //        _endPos.Translate(Vector3.forward);

    }
    void OnDisable()
    {
        Debug.Log("ExitMove");
    }
	void Update ()
    {
        _t += Time.deltaTime;
        Vector3 deltaMove = _forward * d.moveSpeed ;
        cc.Move(deltaMove * Time.deltaTime);
    //    transform.position = Vector3.Lerp(_startPos, _endPos, _t * d.moveSpeed);

     /*   if(_t * d.moveSpeed > 1f)
        {
            _t = 0f;
            _startPos = transform.position;
            _endPos = transform.position + _forward;
        }*/
	}
   
}
