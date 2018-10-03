using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

struct StringDisplayRequest
{
    public string m_message;
    public float m_duration;
    public float m_requestedTime;

    public StringDisplayRequest(string m, float d)
    {
        m_message = m;
        m_duration = d;
        m_requestedTime = Time.time;
    }
}

public class TutorialSection : Singleton<TutorialSection> {

 
    public Text textViewer;

    Queue<StringDisplayRequest> m_lowPrioity = new Queue<StringDisplayRequest>();
    Queue<StringDisplayRequest> m_mediumPriotiy = new Queue<StringDisplayRequest>();
    Queue<StringDisplayRequest> m_highPriority = new Queue<StringDisplayRequest>();

    public void Start()
    {
        StartCoroutine(TextDisplayer());
    }
    public void DisplayText(string helpText, float duration, int priority = 0)
    {
        switch(priority)
        {
            case 0:
                m_lowPrioity.Enqueue(new StringDisplayRequest(helpText, duration));
                break;
            case 1:
                m_mediumPriotiy.Enqueue(new StringDisplayRequest(helpText, duration));
                break;
            case 2:
                m_highPriority.Enqueue(new StringDisplayRequest(helpText, duration));
                break;       
        }
    }

    IEnumerator TextDisplayer()
    {
        while(true)
        {
            StringDisplayRequest topRequest = new StringDisplayRequest();

            float highScore = m_highPriority.Count > 0 ? (Time.time - m_highPriority.Peek().m_requestedTime) : 0;
            float mediumScore = m_mediumPriotiy.Count > 0 ? (Time.time - m_mediumPriotiy.Peek().m_requestedTime)/2.0f : 0;
            float lowScore = m_lowPrioity.Count > 0 ? (Time.time - m_lowPrioity.Peek().m_requestedTime)/3.0f : 0;

            if((highScore +mediumScore +lowScore) == 0)
            {
                yield return new WaitForEndOfFrame();
            }
            else if(highScore > mediumScore && highScore > lowScore)
            {
                topRequest = m_highPriority.Dequeue();
            }
            else if( mediumScore > lowScore)
            {
                topRequest = m_mediumPriotiy.Dequeue();
            }
            else
            {
                topRequest = m_lowPrioity.Dequeue();
            }

            textViewer.text = topRequest.m_message;
            yield return new WaitForSeconds(topRequest.m_duration);
            textViewer.text = "";
        }
    }
    
}
