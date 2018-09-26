using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int sceneBuildIndex = 0;

    //Touch door = change level
    private void OnTriggerEnter(Collider other)
    {
        if(other == Camera.main.GetComponent<Collider>())
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }

    void Restart()
    {
        if(Input.GetButtonDown("R"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void RageQuit()
    {
        if (Input.GetButtonDown("Escape"))
        {
            Application.CancelQuit();
        }
    }
}
