using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Vector3 wayPoint;
    private GameObject[] keys;

    private void Start()
    {
        wayPoint = GameObject.FindGameObjectWithTag("SpawnSpot").GetComponent<Transform>().position;
        keys = GameObject.FindGameObjectsWithTag("Key");
    }
    private void OnCollisionEnter(Collision collision)
    {
        //restart level, died (not for tutorial level, build index = 0)
        if (collision.gameObject.tag == "Floor" && SceneManager.GetActiveScene().buildIndex != 0)
        {
            //setting the keys back
            for(int i = 0; i < keys.Length; i++)
            {
                if (!keys[i].activeInHierarchy) keys[i].SetActive(true);
            }
            KeyCollector.Instance.keyCount = 0;

            this.gameObject.GetComponent<Transform>().position = wayPoint;
        }
    }
}
