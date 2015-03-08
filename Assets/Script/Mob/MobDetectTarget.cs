using UnityEngine;
using System.Collections;

public class MobDetectTarget : MonoBehaviour {

    public MobData data;

    public float detectPeriod = 1f;

    float elapsedTime;

	// Use this for initialization
	void Start () {
        SetPosToMove(data.mob.transform.position);
        elapsedTime = detectPeriod;
    }
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > detectPeriod) {
            DetectTarget();
            elapsedTime = 0f;
        }
    }

    void DetectTarget() {
        Ray ray = CreateRay(data.mob.transform);
        RaycastHit hitInfo;
        bool raycast = Physics.Raycast(ray, out hitInfo, data.visualRange);
        if (raycast == true && hitInfo.collider.gameObject == data.target) {
            Debug.Log("Detect target: player!!!");
            data.lastMoveTime = Time.time;
            SetPosToMove(data.target.transform.position);
        } else {
            float idleTime = Time.time - data.lastMoveTime;
            if (idleTime >= data.maxIdleTime && IsBlocked() == false) {
                data.lastMoveTime = Time.time;
                SetPosToMove(data.mob.transform.position + data.mob.transform.forward);
            } else {
                SetPosToMove(data.mob.transform.position);
                TurnRandomly();
            }
        }
    }

    void SetPosToMove(Vector3 pos) {
        data.xToMove = Mathf.Round(pos.x);
        data.zToMove = Mathf.Round(pos.z);
    }

    void TurnRandomly() {
        float[] degrees = { 90f, -90f };
        int r = Random.Range(0, degrees.Length);
        float degree = degrees[r];
        data.mob.transform.rotation *= Quaternion.Euler(Vector3.up * degree);
    }

    bool IsBlocked() {
        Ray ray = CreateRay(data.mob.transform);
        RaycastHit hitInfo;
        float range = 1f;
        bool raycast = Physics.Raycast(ray, out hitInfo, range);
        return raycast;
    }

    static Ray CreateRay(Transform tran) {
        return new Ray(tran.position + (new Vector3(0f, 0.3f, 0f)), tran.forward);
    }
}
