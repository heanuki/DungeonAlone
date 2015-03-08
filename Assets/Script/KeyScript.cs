using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour 
{
    public float turnspeed = 50f;
    public AudioClip DistroySnd;

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("getkey");
        AudioSource.PlayClipAtPoint(DistroySnd, transform.position);
        col.transform.GetComponent<FSMPlayerData>().keyNum++;
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f), Time.deltaTime * turnspeed);
       // transform.Translate(0f, Mathf.Sin(Time.deltaTime), 0f);
    }

}
