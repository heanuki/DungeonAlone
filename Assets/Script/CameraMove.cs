using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public Transform endPosTrans;
    public float speed = 1f;
    public float offsetToChar = 2f;
    void Awake()
    {
        startPos = transform.position;
        endPos = endPosTrans.position - new Vector3(0f, 0f, offsetToChar);
    }
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime);
	}
}
