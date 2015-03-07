#pragma strict

var healthPoint = 1;			//몬스터의 체력
var physicalPower = 1;			//몬스터의 물리공격력 
var rewardExp = 1;
var rewardKey = 0;
var battleSnd : AudioClip;		//전투효과음 
var DistroySnd : AudioClip;		//제거효과음 


function OnTriggerEnter(coll : Collider) {
	AudioSource.PlayClipAtPoint(battleSnd, transform.position);			//사운드 출력
	this.healthPoint -= js_Status.physicalPower;						//몬스터의 체력 계산
	
	//몬스터 사망 처리
	if (this.healthPoint <= 0) {										
		AudioSource.PlayClipAtPoint(DistroySnd, transform.position);	//제거효과음 
		Destroy(gameObject);											//몬스터 제거 
		js_Status.exp += rewardExp;										//경험치 보상
		// js_Status.key += rewardKey;										//열쇠 보상 
		return;															//이대로 연산 종료
	}
	
	js_Status.healthPoint -= physicalPower;
	
	coll.transform.Translate(Vector3.back);
}

function Start () {

}

function Update () {

}