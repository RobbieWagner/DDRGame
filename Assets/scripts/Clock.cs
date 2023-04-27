using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [HideInInspector] public static float time;
    bool trackingTime;

    void Start() 
    {
        trackingTime = false;
        time = 0;
    }

    public void StartClock()
    {
        trackingTime = true;
        StartCoroutine(TrackTime());
    }

    public void StartClock(float startTime)
    {
        trackingTime = true;
        time = startTime;
        StartCoroutine(TrackTime());
    }

    public void StopClock()
    {
        trackingTime = false;
    }

    public void RestartClock()
    {
        time = 0;
    }

    private IEnumerator TrackTime()
    {
        while(trackingTime)
        {
            yield return new WaitForSeconds(.01f);
            time += .01f;
            //Debug.Log(time);
        }

        StopCoroutine(TrackTime());
    }
}
