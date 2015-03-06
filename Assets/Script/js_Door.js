#pragma strict

var snd : AudioClip;	//문열 때 효과음 

function OnTriggerEnter(coll : Collider) {
	if (js_Status.key == 0) {
		coll.transform.Translate(Vector3.back);					//못가게 막음 	
	}
	else {
		Destroy(gameObject);					//문 열림 
		js_Status.key -= 1;						//키 소모
		AudioSource.PlayClipAtPoint(snd, transform.position);	//사운드 출력 
	}
}

function Start () {

}

function Update () {

}