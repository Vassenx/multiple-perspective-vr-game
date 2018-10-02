using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour {
    public static int keyCount;
    public static int keysInScene;

    private void Start()
    {
        keyCount = 0;
        //defaulting to two
        keysInScene = 2;
    }

    private void OnCollisionEnter(Collision other)
    {
        //player grabs key
        if(other.gameObject.tag == "Key")
        {
            keyCount++;
            other.gameObject.SetActive(false);
        }
    }
}
