#pragma strict

private var speed = 50;	//이동속도 



function Start () {

}

function Update () {

	var amtMove = speed * Time.smoothDeltaTime;	//매프레임당 이동거리 
	
	//전후진 
	if (Input.GetKeyDown("up")) {
		transform.Translate(Vector3.forward);
	}
	if (Input.GetKeyDown("down")) {
		transform.Translate(Vector3.back);
	}
	//좌우이동
	if (Input.GetKeyDown("left")) {
		transform.Translate(Vector3.left);
	}
	if (Input.GetKeyDown("right")) {
		transform.Translate(Vector3.right);
	}
	//위치리셋 
	if (Input.GetKeyDown("space")) {
		transform.Translate(Vector3.zero);
	}

}