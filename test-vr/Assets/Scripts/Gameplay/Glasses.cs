using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : MonoBehaviour {

    public ColorFilter filter;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainCamera")
        {
            CameraFilterManager.Instance.AddFilter(filter);
        }
    }
}
