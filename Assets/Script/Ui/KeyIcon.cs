using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KeyIcon : MonoBehaviour {
    public GameObject[] keyIcons;
    public FSMPlayerData playerData;

    int prevKeysSize;

    void Awake() {
        playerData = GameObject.Find("Player").GetComponent<FSMPlayerData>();
        prevKeysSize = 0;
    }

    void Update() {
        int keysSize = playerData.keyNum;
        if (keysSize == prevKeysSize) {
            return;
        }

        int displaySize = Mathf.Min(keysSize, keyIcons.Length);
        int i = 0;
        for (; i < displaySize; ++i) {
            keyIcons[i].SetActive(true);
        }
        for (; i < keyIcons.Length; ++i) {
            keyIcons[i].SetActive(false);
        }

        prevKeysSize = keysSize;
	}
}
