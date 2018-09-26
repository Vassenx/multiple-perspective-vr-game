using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class GlassHolder : MonoBehaviour {

    public Glasses m_activeObject;
    public ColorFilter m_activeFilter = ColorFilter.Red;
    private bool m_axisInUse = false;
    public Glasses RedGlasses;
    public Glasses GreenGlasses;
    public Glasses BlueGlasses;

    public void OnEnable()
    {

    }

    public void Update()
    {
        if(GameObject.Find("RightController") == null)
        {
            return;
        }

        if (m_activeObject == null)
        {
            m_activeObject = SpawnPrefab(GetMatchingPrefab());
        }

        if (!m_axisInUse && Input.GetAxis(InputMappingAxisUtility.CONTROLLER_RIGHT_TRIGGER) > 0.5)
        {
            m_axisInUse = true;
            m_activeFilter = (ColorFilter)(((int)m_activeFilter + 1) % 3);
            m_activeObject.transform.parent = null;
            m_activeObject.GetComponent<Rigidbody>().isKinematic = false;
            m_activeObject.GetComponent<Rigidbody>().useGravity = true;
            m_activeObject.GetComponent<Collider>().isTrigger = false;
            m_activeObject.gameObject.layer = 9; //glasses and camera collision ignored

            Destroy(m_activeObject.gameObject, 10);
            Destroy(m_activeObject);
            m_activeObject = SpawnPrefab(GetMatchingPrefab());
        }
        else if(m_axisInUse && Input.GetAxis(InputMappingAxisUtility.CONTROLLER_RIGHT_TRIGGER) < 0.5)
        {
            m_axisInUse = false;
        }

        if(Input.GetButtonDown(InputMappingAxisUtility.CONTROLLER_RIGHT_BUMPER_OR_GRIP))
        {
            CameraFilterManager.Instance.ClearFilter();
        }
    }

    private Glasses GetMatchingPrefab()
    {
        switch(m_activeFilter)
        {
            case ColorFilter.Red:
                return RedGlasses;
            case ColorFilter.Green:
                return GreenGlasses;
            case ColorFilter.Blue:
                return BlueGlasses;
            default:
                return null;
        }
    }

    private Glasses SpawnPrefab(Glasses prefab)
    {
        return Instantiate(prefab, GameObject.Find("RightController").transform).GetComponent<Glasses>();
    }
}
