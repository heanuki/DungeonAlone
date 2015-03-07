using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public enum ButtonState : int
{
    Move = 0,
    Torch,
    UseKey,
    Lever,
    Barrel,


}
public class ChangeButtonType : MonoBehaviour
{
    public ButtonState states;
    public Image[] btnImage;
    public GameObject player;


    void Awake()
    {
        btnImage = GetComponentsInChildren<Image>();
        OnChangeButtonImage(ButtonState.Move);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnChangeButtonImage(ButtonState type)
    {
        states = type;
        foreach (Image img in btnImage)
        {
            img.enabled = false;
        }
        btnImage[(int)states].enabled = true;
    }
    public void OnClick()
    {
  //      Debug.Log("button Clicked" + states);
        if(states == ButtonState.Torch)
        {
            player.SendMessage("toggleTorch", SendMessageOptions.RequireReceiver);
        }
        else if(states == ButtonState.UseKey)
        {
            player.SendMessage("UseKeyDoor", SendMessageOptions.RequireReceiver);
        }
        else if (states == ButtonState.Lever)
        {
            player.SendMessage("UseLever", SendMessageOptions.RequireReceiver);
        }
        else if (states == ButtonState.Barrel)
        {
            player.SendMessage("AttackBarrel", SendMessageOptions.RequireReceiver);
        }
    }


}
