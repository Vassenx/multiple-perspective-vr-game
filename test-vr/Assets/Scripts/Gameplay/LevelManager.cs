using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int sceneBuildIndex = 1;

    //Touch door = change level
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Camera.main.gameObject)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }

    void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
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
