using UnityEngine;
using System.Collections;

public class FSMPlayerIdle : FSMPlayer
{
    void OnEnable()
    {
        Vector3 modifiedPos = transform.position;
        modifiedPos.x = Mathf.Round(modifiedPos.x);
        modifiedPos.z = Mathf.Round(modifiedPos.z);
        transform.position = modifiedPos; 
    }
    void OnDisable()
    {
       // Debug.Log("ExitIdle");
    }
	void Update ()
    {
        
        
	}
 
}
