using UnityEngine;
using System.Collections;

public class LeverScript : MonoBehaviour
{
    public KeyDoor MyDoor;
    public RotateLever rotLever;   
    bool _bOpened = false;
    public float rotateSpeed = 40f;

    void onMoveLever()
    {
        if (!_bOpened)
        {
            audio.Play();
            MyDoor.SendMessage("OnOpenDoor", SendMessageOptions.RequireReceiver);
            _bOpened = true;
            rotLever.bUsed = true;
        }
        
    }

}
