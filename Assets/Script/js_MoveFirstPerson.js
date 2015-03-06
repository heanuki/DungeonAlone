#pragma strict

private var hit : RaycastHit;

function Start () {

}

function Update () {

	//FirstPerson Mode는 후진이 없음 
	/*
	if (Input.GetKeyDown("down")) {
		transform.Translate(Vector3.back);
	}
	*/
	//좌우회전
	if (Input.GetKeyDown("left")) {
		transform.Rotate(Vector3(0, -90, 0));
		//iTween.RotateBy(gameObject, iTween.Hash("y", -0.25, "time", 0));
		//이동을 부드럽게 하기 위해 시간을 넣었더니 그 동안 발생하는 키입력으로 인해 좌표가 꼬인다.
		//이동하는 시간 동안 키입력을 받지 않는 기능이 필요하다.
	}
	if (Input.GetKeyDown("right")) {
		transform.Rotate(Vector3(0, 90, 0));
		//iTween.RotateBy(gameObject,iTween.Hash("y", 0.25, "time", 0));

	}
	
	//전진 
	if (Input.GetKeyDown("up")) {
		transform.Translate(Vector3.forward);

		//iTween.MoveBy(gameObject,iTween.Hash("z", 1, "time", 0));

	}
}