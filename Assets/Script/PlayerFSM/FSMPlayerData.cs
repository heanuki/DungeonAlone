using UnityEngine;

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
    public bool bCanReceiveInput = true;
	//public int layerMask;
    public GameObject UIPanel;

    public int keyNum = 0;
	
	protected override void Awake()
	{
		base.Awake();
		anim = GetComponentInChildren<Animator>();
		cc = GetComponent<CharacterController>();
        UIPanel = GameObject.FindGameObjectWithTag("InputUIPanel");

	}
    void AddKey(int num)
    {
        keyNum += num;
    }
    void Update()
    {

    }
    //void OnGUI()
    //{
    //    GUI.Label(new Rect(10, 90, 120, 20), "열쇠 : " + keyNum);
    //}
}
