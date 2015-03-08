using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BalloonDisabled : MonoBehaviour {

    public float EnabledTime = 1f;
    public  float _t;
    public GameObject btn;

    void Awake()
    {
        _t = EnabledTime;
    }
	// Update is called once per frame
	void Update () 
    {
        if (transform.localScale.x > 0f)
        {
            if (_t < 0f)
            {
                transform.localScale = new Vector3(0f, 0f, 0f);
                _t = EnabledTime;
            }
            _t -= Time.deltaTime;
        }
	}
}
