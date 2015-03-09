using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NearbyMob : MonoBehaviour 
{
    public GameObject temp;
    public GameObject pc;
    public float damageCycle = 1f;
	public float mobDamage = 10f;

    void Awake()
    {
        temp = GameObject.FindGameObjectWithTag("Balloon") ;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //temp.SetActive(true);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
            pc = col.transform.gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            temp.transform.localScale = new Vector3(0f, 0f, 0f);
            pc = null;
        }
    }
    void Update()
    {
        if(pc != null)
        {
            if (damageCycle < 0f)
            {
               // Debug.Log("damaged!!!");
				pc.SendMessage("Damaged", mobDamage, SendMessageOptions.RequireReceiver);
                damageCycle = 2f;
            }
            damageCycle -= Time.deltaTime;
            
        }
    }
}
