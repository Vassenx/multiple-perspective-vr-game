using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class CheckPointManager : Singleton<CheckPointManager> {

    private Transform m_lastCheckpoint;

    void Start()
    {
        this.transform.position = Vector3.zero;
        m_lastCheckpoint = this.transform;
    }

    public void SetLatestCheckPoint(Transform p)
    {
        m_lastCheckpoint = p;
    }

    public Transform GetLastCheckPoint()
    {
        return m_lastCheckpoint.transform;
    }
}
