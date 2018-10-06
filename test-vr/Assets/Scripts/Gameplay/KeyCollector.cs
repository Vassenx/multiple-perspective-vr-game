using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class KeyCollector : Singleton<KeyCollector>{

    public int keysInScene;
    [HideInInspector]
    public int keyCount;
   
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
