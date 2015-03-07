using UnityEngine;
using System.Collections;

public class FSMDataBase : MonoBehaviour 
{

	public float hp;
	public float maxHp = 100f;
	public float damage;
	public float exp;
	public float maxExp;
	protected virtual void Awake()
	{
		hp = maxHp;
	}
	void GetDamage(float damage)
	{
		hp -= damage;
		if(hp <= 0f)
		{
			//SendMessage("SetState", 4, SendMessageOptions.RequireReceiver);
		}
	}
}
