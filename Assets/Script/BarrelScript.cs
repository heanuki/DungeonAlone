using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour 
{

    void onAttack()
    {
        audio.Play();
        Destroy(gameObject);

    }
}
