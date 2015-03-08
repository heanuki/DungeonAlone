using UnityEngine;
using System.Collections;

public class MobBarrel : MonoBehaviour
{
    public int healthPoint = 1;			//몬스터의 체력
    public int physicalPower = 0;	    //몬스터의 물리공격력 
    public int rewardExp = 0;
    public float GettingMeetRatio = 0.5f;

    public FSMPlayerData pd;
    public GameObject MeetObject;

    public AudioClip DistroySnd;

    void Awake()
    {
        pd = GameObject.FindGameObjectWithTag("Player").GetComponent<FSMPlayerData>();
    }
    void OnTriggerEnter(Collider coll)
    {
        js_Status.healthPoint -= physicalPower;
        coll.transform.Translate(Vector3.back);
       // coll.SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.DontRequireReceiver);
        OnDamage(1);
    }

    void OnDamage(int attkPoint)
    {

        //audio.Play();
        AudioSource.PlayClipAtPoint(DistroySnd, transform.position);

            
        healthPoint -= attkPoint;

    }
    void OnDead()
    {
       // pd.transform.SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.DontRequireReceiver);
      
        Debug.Log("mob dead ");
        //player.SendMessage("SetStates", PlayerStates.Idle, SendMessageOptions.RequireReceiver);
        js_Status.exp += rewardExp;

        SpawnReward();
        Destroy(gameObject);
        //gameObject.SetActive(false);
       
    }
    void SpawnReward()
    {
        if (Random.Range(0f, 1f) < GettingMeetRatio)
        {
            Instantiate(MeetObject, transform.position, transform.rotation);
            //gameObject.
            //여기에 키 스폰  
            //pd.SendMessage("AddKey", 1, SendMessageOptions.RequireReceiver);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (healthPoint <= 0)
        {
            //   transform.Rotation = Vector3.MoveTowards(transform.position, new Vector3(startPos.x, startPos.y - 20f, startPos.z), openSpeed * Time.deltaTime);

            OnDead();
        }

    }
}
