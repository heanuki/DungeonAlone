using UnityEngine;
using System.Collections;

public class KeyDoor : MonoBehaviour {

/*
    function OnTriggerEnter(coll : Collider) {
	if (js_Status.key == 0) {
		//coll.transform.Translate(Vector3.back);					//못가게 막음 	
	}
	else {
		Destroy(gameObject);					//문 열림 
		js_Status.key -= 1;						//키 소모
		AudioSource.PlayClipAtPoint(snd, transform.position);	//사운드 출력 
	}*/
   void OnOpenDoor()
    {
        Destroy(gameObject);
    }
    
}
