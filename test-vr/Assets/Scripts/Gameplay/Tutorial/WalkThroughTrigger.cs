using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class WalkThroughTrigger : MonoBehaviour {

    [System.Serializable]
    public struct Message
    {
        public string message;
        public float duration;
        public int priority;
    }

    public Message messages;

    public EventTrigger.TriggerEvent customCallBack;

    private bool displayedMessage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CameraParent")
        {
            if(!displayedMessage)
            {
                displayedMessage = true;
                TutorialSection.Instance.DisplayText(messages.message, messages.duration, messages.priority);
            }
            else
            {
                BaseEventData eventData = new BaseEventData(EventSystem.current);
                eventData.selectedObject = other.gameObject;
                customCallBack.Invoke(eventData);
            }
        }
    }

    public void ResetPlayerToLastCheckPoint(BaseEventData d)
    {
        //Do something
        d.selectedObject.transform.position = CheckPointManager.Instance.GetLastCheckPoint().position;
    }

    public void ResetPlayerAndFilter(BaseEventData d)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RGBFilterPostFX>().ClearFilter();
        d.selectedObject.transform.position = CheckPointManager.Instance.GetLastCheckPoint().position;
    }

    public void DoNothing(BaseEventData d)
    {
        //empty
    }

    public void SetCheckPoint(BaseEventData d)
    {
        CheckPointManager.Instance.SetLatestCheckPoint(this.transform);
    }
}
