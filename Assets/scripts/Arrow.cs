using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    bool moving;
    Vector3 startingPosition, positionToGoTo;
    float arrowBeat, arrowPauseTime, arrowSpeed;

    void Awake()
    {
        moving = false;
    }

    public void StartArrow(float beat, float pauseTime, float speed, Vector3 startPos, Vector3 endPos)
    {
        arrowBeat = beat;
        arrowPauseTime = pauseTime;
        arrowSpeed = speed;

        startingPosition = startPos;
        positionToGoTo = endPos;

        moving = true;
    }

    void Update()
    {
        if(moving)
        {
            transform.position -= new Vector3(0, arrowSpeed * 2 * Time.deltaTime, 0);
        }
    }

}
