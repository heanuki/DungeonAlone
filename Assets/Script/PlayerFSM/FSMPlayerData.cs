﻿using UnityEngine;
using System.Collections;

public class FSMPlayerData : FSMDataBase 
{
	//public Transform movePoint;
	//public Transform attackPoint;
	
	public CharacterController cc;
	public Animator anim;
	public float moveSpeed = 2f;
	public float rotateSpeed = 360f;
	//public float attackRange = 1.6f;
	
	//public int layerMask;
	
	
	
	protected override void Awake()
	{
		base.Awake();
		anim = GetComponentInChildren<Animator>();
		cc = GetComponent<CharacterController>();

	}
}
