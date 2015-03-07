using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour 
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("getkey");
        audio.Play();
        col.transform.GetComponent<FSMPlayerData>().keyNum++;
    }

}
