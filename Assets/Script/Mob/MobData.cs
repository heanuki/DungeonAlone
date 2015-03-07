using UnityEngine;
using System.Collections;

public class MobData : MonoBehaviour {

    public GameObject mob;

    // 몹이 쫓는 대상
    public GameObject target;

    //  몹의 속도
    public float moveSpeed = 1f;

    // 몹의 가시 거리
    public float visualRange = 3f;

    // 몹의 최대 유휴 시간
    // - 이 시간이 지나도록 쫓을 대상을 발견하지 못하면,
    //   임의로 이동한다.
    public float maxIdleTime = 3f;

    // 몹이 이동하려는 목표 위치
    [HideInInspector]
    public float xToMove;
    [HideInInspector]
    public float zToMove;

    // 몹이 최후로 이동했던 시각
    [HideInInspector]
    public float lastMoveTime;

    void Awake() {
        xToMove = Mathf.Round(mob.transform.position.x);
        zToMove = Mathf.Round(mob.transform.position.z);
        lastMoveTime = Time.time;
    }
}
