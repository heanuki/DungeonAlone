using UnityEngine;
using System.Collections;

public class RotateLever : MonoBehaviour {
    Quaternion _endRot;
    public float turnSpeed = 100f;
    public bool bUsed = false;
    void Awake()
    {
        _endRot = transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, 1f) * -50f);
    }
	void Update () 
    {
        if (bUsed)
        {
            Quaternion nextRot = Quaternion.RotateTowards(
             transform.rotation, _endRot, turnSpeed * Time.deltaTime);

            transform.rotation = nextRot;
        }

    }
}
