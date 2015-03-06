#pragma strict


function OnTriggerEnter(coll : Collider) {
	coll.transform.Translate(Vector3.back);	//못가게 막음 
}

function Start () {

}

function Update () {

}