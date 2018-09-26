using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public float jumpSpeed = 10000;

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        Vector3 up = Camera.main.transform.up;

        right.Set(right.x, 0, right.z);
        forward.Set(forward.x, 0, forward.z);

        forward.Normalize();
        right.Normalize();

        right *= Input.GetAxis(InputMappingAxisUtility.CONTROLLER_RIGHT_STICK_HORIZONTAL);
        forward *= Input.GetAxis(InputMappingAxisUtility.CONTROLLER_RIGHT_STICK_VERTICAL);
       
        right *= Time.deltaTime * speed;
    
        forward *= Time.deltaTime * speed;
        
        this.transform.Translate(forward + right);

        if (Input.GetButtonDown(InputMappingAxisUtility.CONTROLLER_LEFT_BUMPER_OR_GRIP))
        {
            this.GetComponent<Rigidbody>().AddForce(Camera.main.transform.up * jumpSpeed, ForceMode.Impulse);
        }
	}

}
