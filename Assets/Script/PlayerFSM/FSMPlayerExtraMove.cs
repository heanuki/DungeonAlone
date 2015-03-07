using UnityEngine;
using System.Collections;

public class FSMPlayerExtraMove : FSMPlayer
{

    //    Vector3 _forward;
    Vector3 _StartPos;
    Vector3 _EndPos;
    public GameObject InteractionObj;
    // public bool canMove = true;
    void SetCanAction(bool bCanAction)
    {
        // d.bCanReceiveInput = bCanAction;
    }
    void OnEnable()
    {

        // Debug.Log("EnterExtraMove");
        //      _forward = transform.forward;

        if (d.bCanReceiveInput)
        {
            _StartPos = transform.position;
            _EndPos = new Vector3((float)((int)_StartPos.x), transform.position.y, (float)((int)_StartPos.z)) + transform.forward;

            // d.bCanReceiveInput = false;
        }

    }
    void OnDisable()
    {
        //Debug.Log("ExitExtraMove");
    }
    void Update()
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
            {
                SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
                return;
            }

            if (hitInfo.collider.tag == "DOOR" || hitInfo.collider.tag == "KeyDoor")
            {
                InteractionObj = hitInfo.collider.gameObject;
                SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
                return;
            }
            if (hitInfo.collider.tag == "TORCH" || hitInfo.collider.tag == "Lever" || hitInfo.collider.tag == "Barrel")
            {
                // d.UIPanel.SendMessage("OnChangeButtonImage", 1, SendMessageOptions.RequireReceiver);
                InteractionObj = hitInfo.collider.gameObject;
                SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
                return;
            }
        }
        else
            d.UIPanel.SendMessage("OnChangeButtonImage", 0, SendMessageOptions.RequireReceiver);

        Vector3 nextPos = Vector3.MoveTowards(transform.position, _EndPos, d.moveSpeed * Time.deltaTime);
        transform.position = nextPos;
        if (_EndPos == nextPos)
        {
            // d.bCanReceiveInput = true;
            SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        }

    }
    void toggleTorch()
    {
        InteractionObj.audio.Play();
        Torchelight temp = InteractionObj.GetComponent<Torchelight>();
        if (temp.IntensityLight > 0f)
            temp.IntensityLight = 0f;
        else
            temp.IntensityLight = 1f;

    }
    void UseKeyDoor()
    {
        InteractionObj.audio.Play();
        // KeyDoor temp = InteractionObj.GetComponent<KeyDoor>();
        if (d.keyNum > 0)
        {
            InteractionObj.SendMessage("OnOpenDoor", SendMessageOptions.RequireReceiver);
            d.keyNum--;
        }

    }
    void UseLever()
    {
        InteractionObj.SendMessage("onMoveLever", SendMessageOptions.RequireReceiver);
    }
    void AttackBarrel()
    {
        InteractionObj.SendMessage("onAttack", SendMessageOptions.RequireReceiver);
    }
}
