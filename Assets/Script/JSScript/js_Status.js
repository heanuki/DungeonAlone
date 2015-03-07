#pragma strict

static var level = 1;			//레벨
static var maxExp = 3;			//레벨업을 위한 요구 경험치
static var exp = 0;				//경험치
static var maxHealthPoint = 0;	//최대 체력
static var healthPoint = 0;	//현재 체력
static var physicalPower = 1;	//물리공격력
static var key = 0;				//현재 보유한 열쇠 수 
private var _t = 0f;
var darkDamage = 1;
var PlayerDeadSnd : AudioClip;	//플레이어 사망 효과음 

var levelUpSnd : AudioClip;	//레벨업 시 효과음

//주인공의 능력치를 화면에 표시
function OnGUI() {
	GUI.Label(Rect(10, 10, 120, 20), "레벨 : " + level);
	GUI.Label(Rect(10, 30, 120, 20), "경험치 : " + exp + "/" + maxExp);
	GUI.Label(Rect(10, 50, 120, 20), "체력 : " + healthPoint + "/" + maxHealthPoint);
	GUI.Label(Rect(10, 70, 120, 20), "공격력 : " + physicalPower);
	GUI.Label(Rect(10, 90, 120, 20), "열쇠 : " + key);
}

function InitializeStatus () {
	
	level = 1;			
	maxExp = 3;			
	exp = 0;				
	maxHealthPoint = 1000;	
	healthPoint = maxHealthPoint;	
	physicalPower = 1;	
	key = 0;				

}

function PlayerDead() {
		print("You are dead!");
		AudioSource.PlayClipAtPoint(PlayerDeadSnd, transform.position);	//플레이어 사망 효과음 
		Application.LoadLevel("testmapF1");
		gameObject.transform.position = Vector3(0, 0, 0);
		InitializeStatus();
}


function Start () {
	InitializeStatus();
}
function Damaged(){
    
    if(healthPoint > 0)
    {
        healthPoint -= 5;
    }
}
function Update () {

    _t += Time.deltaTime;

    if(_t > 1)
    {
        healthPoint -= darkDamage;
        _t -= 1;
    }


	//레벨업 처리
	if (exp >= maxExp) {				
		level++;						//레벨 증가
		maxHealthPoint += 1;			//레벨업 시 최대 체력 상승
		healthPoint = maxHealthPoint;	//레벨업 시 체력회복
		physicalPower += 1;				//레벨업 시 공격력 상승
		maxExp += 2;					//최대 경험치 증가 
		exp = 0;						//경험치 초기화
		AudioSource.PlayClipAtPoint(levelUpSnd, transform.position);	//사운드 출력
		
	}

	if (healthPoint < 1) {
		PlayerDead();
	}
}