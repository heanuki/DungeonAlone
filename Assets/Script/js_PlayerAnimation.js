#pragma strict

function Start () {

}

function Update () {
	
	//걷기 애니메이션 처리

	if (Input.GetKeyDown("up")) {	// 전진입력 시 이동 동작 
		animation["run"].wrapMode = WrapMode.Once;
		animation.CrossFade("run");
	}
	
	if (!animation.IsPlaying("run")) {	//이동 동작 후 아이들 동작. 추후 부드럽게 개선 필요.
            animation.CrossFade("idle");
    }
    	
}