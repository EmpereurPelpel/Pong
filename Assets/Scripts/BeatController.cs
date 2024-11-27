using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatController : MonoBehaviour
{
    [SerializeField] private float bpm;

    [SerializeField] private AudioSource musicSource;

    [SerializeField] private Intervals[] intervals;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       foreach (Intervals interval  in intervals) 
        {
            float sampledTime = (musicSource.timeSamples / (musicSource.clip.frequency * interval.GetIntervalLength(bpm)));
            interval.CheckForNewInterval(sampledTime);
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float steps;
    [SerializeField] private UnityEvent trigger;
    [SerializeField] private float delay = -0.5f;

    private int lastInterval = -1;

    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * steps);
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval + delay) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
            //Debug.Log(lastInterval);
        }
        
    }
}