using UnityEngine;
//using UnityEngine.UI;

using System.Collections;

public class CameraMove : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public Transform endPosTrans;
    public float speed = 1f;
    public float offsetToChar = 2f;

   // public Image touchStartImage;
    void Awake()
    {
        startPos = transform.position;
        endPos = endPosTrans.position - new Vector3(0f, -0.25f, offsetToChar);
    //    touchStartImage.color = new Color(touchStartImage.color.r, touchStartImage.color.g, touchStartImage.color.b, 0f);
    }
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime);
    //    touchStartImage.color = Color.Lerp(touchStartImage.color, new Color(touchStartImage.color.r, touchStartImage.color.g, touchStartImage.color.b, 1f), Time.deltaTime * Time.deltaTime);
        
	}
}
