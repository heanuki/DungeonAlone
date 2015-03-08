using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchStartScript : MonoBehaviour {

    public float t = 3f;
	// Use this for initialization
	void Awake () {
        Color temp = GetComponentInParent<Image>().color;
        GetComponentInParent<Image>().color = new Color(temp.r, temp.g, temp.b, 0f);
	}
	
	// Update is called once per frame
	void Update () {

	    if(t  < 0f)
        {
            Color temp = GetComponentInParent<Image>().color;
            GetComponentInParent<Image>().color = new Color(temp.r, temp.g, temp.b, 1f);

            if (Input.GetMouseButtonDown(0)) {
                string firstStage = "0F";
                Application.LoadLevel(firstStage);
            }
        }
        t -= Time.deltaTime;
	}
}
