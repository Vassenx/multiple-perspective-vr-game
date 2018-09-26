using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using HoloToolkit.Unity.InputModule;
public class Eyes : MonoBehaviour {

    public GameObject eyes;
    public Material img1;
    public Material img2;
    bool seen = false;
	
	void Update () {
		if(GazeManager.Instance.HitObject == eyes && !seen) {
            eyes.GetComponent<MeshRenderer>().material = img1;
            StartCoroutine(Wait());
        }
	}

    IEnumerator Wait() {
        seen = true;
        yield return new WaitForSeconds(2);
        eyes.GetComponent<MeshRenderer>().material = img2;
    }
}
