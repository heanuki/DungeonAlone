using UnityEngine;
using System.Collections;

public class FSMPlayer : FSMBase 
{
    public FSMPlayerData d;
    public CharacterController cc;

    void Awake()
    {

        d = GetComponent<FSMPlayerData>();
        cc = GetComponent<CharacterController>();
    }
}
