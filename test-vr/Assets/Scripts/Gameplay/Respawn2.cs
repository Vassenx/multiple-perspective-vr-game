using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn2 : MonoBehaviour
{
    public Vector3 wayPoint;

    private void Start()
    {
        wayPoint = GameObject.FindGameObjectWithTag("SpawnSpot").GetComponent<Transform>().position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //restart level, died
        if (collision.gameObject.tag == "Floor" && SceneManager.GetActiveScene().buildIndex == 1)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            this.gameObject.GetComponent<Transform>().position = wayPoint;
            //this.gameObject.transform.position = CheckPointManager.Instance.GetLastCheckPoint().position;
        }
    }
}
