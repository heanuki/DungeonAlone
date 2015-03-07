using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public Transform endPosTrans;
    public float speed = 1f;
    void Awake()
    {
        startPos = transform.position;
        endPos = endPosTrans.position;
    }
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime);
	}
}
