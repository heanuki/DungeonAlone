using UnityEngine;
using System.Collections;

public class FSMPlayerMove : FSMPlayer
{

     //    Vector3 _forward;
     Vector3 _StartPos;
     Vector3 _EndPos;

    
    void OnEnable()
    {
        _StartPos = transform.position;
        _EndPos = new Vector3((float)((int)_StartPos.x), transform.position.y, (float)((int)_StartPos.z)) + transform.forward;

    }
    void OnDisable()
    {
        //Debug.Log("ExitExtraMove");
    }
    void Update()
    {
        Ray r = new Ray(_StartPos, _EndPos - _StartPos);
        RaycastHit hitInfo;
        if(Physics.Raycast(r, out hitInfo, 1f))
        {
            if(hitInfo.collider.tag == "WALL")
                return;
        }
        Vector3 nextPos = Vector3.MoveTowards(transform.position, _EndPos, d.moveSpeed * Time.deltaTime);
        transform.position = nextPos;
        if(_EndPos == nextPos)
        {
            _StartPos = transform.position;
            _EndPos = new Vector3((float)((int)_StartPos.x), transform.position.y, (float)((int)_StartPos.z)) + transform.forward;

        }

    }
   
}
