using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int sceneBuildIndex = 1;
    private GameObject player;

    private void Start()
    {
        player = Camera.main.gameObject;
    }

    //Touch door = change level
    private void OnTriggerEnter(Collider other)
    {
        //have to have all the keys to get through door
        if(other.gameObject == player && KeyCollector.Instance.keyCount == KeyCollector.Instance.keysInScene)
        {
            SceneManager.LoadScene(sceneBuildIndex);
            KeyCollector.Instance.keyCount = 0;
        }
    }

    void RageQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.CancelQuit();
        }
    }
}
