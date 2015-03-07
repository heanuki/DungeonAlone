using UnityEngine;
using System.Collections;

public class KeyDoor : MonoBehaviour 
{
    bool bUsed = false;
    Vector3 startPos;
    public float openSpeed = 10f;
   void OnOpenDoor()
    {
        startPos = transform.position;
        bUsed = true;
        Destroy(gameObject, 10f);
    } 
    void Update()
   {
        if(bUsed)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPos.x, startPos.y - 20f, startPos.z), openSpeed * Time.deltaTime);
        }
   }
}
