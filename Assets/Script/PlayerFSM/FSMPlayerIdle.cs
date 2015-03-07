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

        
        d.bCanReceiveInput = true;
       // SendMessage("SetCanAction", true, SendMessageOptions.RequireReceiver);
    }
    void OnDisable()
    {
       // Debug.Log("ExitIdle");
    }
	void Update ()
    {
        Vector3 _StartPos = transform.position;
        Vector3 _EndPos = new Vector3((float)((int)_StartPos.x), transform.position.y, (float)((int)_StartPos.z)) + transform.forward;

        Ray r = new Ray(_StartPos, _EndPos - _StartPos);
        RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, 1f))
        {
           
            if (hitInfo.collider.tag == "TORCH")
            {
                d.UIPanel.SendMessage("OnChangeButtonImage", 1, SendMessageOptions.RequireReceiver);
               // torch = hitInfo.collider.GetComponent<Torchelight>();
               // SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
                return;
            }
            if (hitInfo.collider.tag == "KeyDoor")
            {
                d.UIPanel.SendMessage("OnChangeButtonImage", 2, SendMessageOptions.RequireReceiver);
                // torch = hitInfo.collider.GetComponent<Torchelight>();
                // SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
                return;
            }
        }
        else
            d.UIPanel.SendMessage("OnChangeButtonImage", 0, SendMessageOptions.RequireReceiver);

	}
 
}
