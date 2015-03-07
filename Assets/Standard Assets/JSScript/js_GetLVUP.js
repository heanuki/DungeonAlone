#pragma strict

var snd : AudioClip;	//습득 시 효과음


function OnTriggerEnter(coll : Collider) {
	AudioSource.PlayClipAtPoint(snd, transform.position);	//사운드 출력
	Destroy(gameObject);									//레벨업 구슬 제거
	js_Status.exp += js_Status.maxExp;					//경험치 상승으로 레벨 증가
}

function Start () {

}

function Update () {



}