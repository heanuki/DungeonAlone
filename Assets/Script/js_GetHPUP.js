#pragma strict

var snd : AudioClip;	//습득 시 효과음


function OnTriggerEnter(coll : Collider) {
	AudioSource.PlayClipAtPoint(snd, transform.position);	//사운드 출력
	Destroy(gameObject);									//HP 구슬 제거
	if (js_Status.healthPoint < js_Status.maxHealthPoint) {	//최대 체력과 현재 체력 비교
		js_Status.healthPoint += 1;							//HP 증가
	}
}

function Start () {

}

function Update () {



}