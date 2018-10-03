using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector3 pos;
    public Vector3 direction;
    public int time;
    public int length;

    private void Start()
    {
        pos = this.gameObject.GetComponent<Transform>().position;
    }

    void Update () {
        this.gameObject.GetComponent<Transform>().position = pos + direction.normalized * Mathf.Cos(Time.time * Mathf.PI*2.0f/ time) * length;
    }
}
