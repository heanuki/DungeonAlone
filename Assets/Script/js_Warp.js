#pragma strict


var stageName = "testmapF2";
var startPointX = 9;
var startPointY = 0;
var startPointZ = -9;

function OnTriggerEnter(coll : Collider) {
	Application.LoadLevel(stageName);
	coll.transform.position = Vector3(startPointX, startPointY, startPointZ);
}

function Start () {

}

function Update () {

}
