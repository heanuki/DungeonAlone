using UnityEngine;
using System.Collections;

public class MobMove : MonoBehaviour {

    public MobData data;

	// Update is called once per frame
	void Update () {
        if (IsArrived()) {
            return;
        }

        if (IsBlocked()) {
            StopMoving();
        }

        Move();
    }

    bool IsArrived() {
        float distX = data.xToMove - data.mob.transform.position.x;
        float distZ = data.zToMove - data.mob.transform.position.z;
        return (distX == 0 && distZ == 0);
    }

    bool IsBlocked() {
        Ray ray = CreateRay(data.mob.transform);
        RaycastHit hitInfo;
        float range = 1f;
        bool raycast = Physics.Raycast(ray, out hitInfo, range);
        return raycast;
    }

    void StopMoving() {
        data.xToMove = Mathf.Round(data.mob.transform.position.x);
        data.zToMove = Mathf.Round(data.mob.transform.position.z);
    }

    void Move() {
        float distX = data.xToMove - data.mob.transform.position.x;
        float distZ = data.zToMove - data.mob.transform.position.z;

        float deltaDist = data.moveSpeed * Time.deltaTime;
        if (distX != 0) {
            deltaDist = Mathf.Min(deltaDist, Mathf.Abs(distX));
            data.mob.transform.position += new Vector3(Mathf.Sign(distX) * deltaDist, 0f, 0f);
        } else if (distZ != 0) {
            deltaDist = Mathf.Min(deltaDist, Mathf.Abs(distZ));
            data.mob.transform.position += new Vector3(0f, 0f, Mathf.Sign(distZ) * deltaDist);
        }
    }

    static Ray CreateRay(Transform tran) {
        return new Ray(tran.position, tran.forward);
    }
}
