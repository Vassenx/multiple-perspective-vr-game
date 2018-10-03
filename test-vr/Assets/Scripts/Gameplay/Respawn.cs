using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        //restart level, died
        if(collision.gameObject.tag == "Floor")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
