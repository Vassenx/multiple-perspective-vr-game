using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    private Vector3 spawnSpot; 

    private void Start()
    {
        spawnSpot = GameObject.FindGameObjectWithTag("SpawnSpot").GetComponent<Transform>().position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            this.GetComponent<Transform>().position = spawnSpot;
        }
    }
}
