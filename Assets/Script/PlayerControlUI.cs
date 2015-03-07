using UnityEngine;
using System.Collections;

public class PlayerControlUI : MonoBehaviour 
{
    public GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnButtonDownMove()
    {
        player.SendMessage("Move", SendMessageOptions.RequireReceiver);
    }
    public void OnButtonDownTurnLeft()   
    {
        player.SendMessage("TurnLeft", SendMessageOptions.RequireReceiver);
    }
    public void OnButtonDownTurnRight()
    {
        player.SendMessage("TurnRight", SendMessageOptions.RequireReceiver);
    }
    public void OnButtonUp()
    {
        player.SendMessage("Idle", SendMessageOptions.RequireReceiver);
    }
    public void OnButtonUpMove()
    {
        player.SendMessage("ExtraMove", SendMessageOptions.RequireReceiver);
    }
    public void OnButtonUpLeft()
    {
        player.SendMessage("ExtraTurnLeft", SendMessageOptions.RequireReceiver);
    }
    public void OnButtonUpRight()
    {
        player.SendMessage("ExtraTurnRight", SendMessageOptions.RequireReceiver);
    }
}
