#pragma strict

var snd : AudioClip;	//습득 시 효과음


function OnTriggerEnter(coll : Collider) {
	AudioSource.PlayClipAtPoint(snd, transform.position);	//사운드 출력
	Destroy(gameObject);									//HP 구슬 제거
	js_Status.key += 1;							//HP 증가
}

function Start () {

}

function Update () {



}