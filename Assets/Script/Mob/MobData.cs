﻿using UnityEngine;
using System.Collections;

public class MobData : MonoBehaviour {

    public GameObject mob;

    // 몹이 쫓는 대상
    public GameObject target;

    //  몹의 속도
    public float moveSpeed;

    // 몹의 가시 거리
    public float visualRange;

    // 몹이 이동하려는 목표 위치
    public float xToMove;
    public float zToMove;

    void Awake() {
        moveSpeed = 1f;
        visualRange = 3f;
        xToMove = Mathf.Round(mob.transform.position.x);
        zToMove = Mathf.Round(mob.transform.position.z);
    }
}
