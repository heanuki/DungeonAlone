using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour {
    public Image hpValue;
    js_Status playerStatus;

    void Awake() {
        playerStatus = GameObject.Find("Player").GetComponent<js_Status>();
    }

	void Update () {
        hpValue.fillAmount = (float) js_Status.healthPoint / (float) js_Status.maxHealthPoint;
    }
}
