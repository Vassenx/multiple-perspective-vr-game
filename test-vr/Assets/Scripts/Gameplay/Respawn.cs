using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        //restart to last checkpoint, for tutorial sequence 
        if(collision.gameObject.tag == "Floor" && SceneManager.GetActiveScene().buildIndex == 0)
        {
            this.gameObject.transform.position = CheckPointManager.Instance.GetLastCheckPoint().position;
        }
    }
}
