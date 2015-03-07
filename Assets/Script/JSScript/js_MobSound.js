#pragma strict


var idleSnd : AudioClip;		//노이즈효과음 

function OnTriggerEnter(coll : Collider) {
    AudioSource.PlayClipAtPoint(idleSnd, transform.position);			//사운드 출력
}

function Start () {

}

function Update () {

}