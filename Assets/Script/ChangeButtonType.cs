﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public enum ButtonState : int
{
    Move = 0,
    Torch,
 //   Switch,
 //   UseKey,

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
        Debug.Log("button Clicked" + states);
        if(states == ButtonState.Torch)
        {
            player.SendMessage("toggleTorch", SendMessageOptions.RequireReceiver);
        }
    }


}