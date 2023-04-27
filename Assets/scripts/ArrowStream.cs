using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStream : MonoBehaviour
{
    public GameObject arrow;
    private Queue<Arrow> arrows;

    [SerializeField] int arrowDirection;

    [SerializeField] PlunderStatistics plunderStatistics;

    [SerializeField] Transform targetSpot;

    [SerializeField] float maxDistanceUnderTarget = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        arrows = new Queue<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        if(arrows.Count > 0 && arrows.Peek().transform.position.y < targetSpot.position.y)
        {
            float distance = Vector2.Distance(arrows.Peek().transform.position, targetSpot.position);
            if (distance >= maxDistanceUnderTarget)
            {
                RemoveArrow();
                plunderStatistics.ChangeStatistics(4, arrowDirection);
            }
        }
    }

    public void AddArrow(float beat, float pauseTime, float speed)
    {
        Transform newArrowT = Instantiate(arrow, targetSpot).transform;
        Vector3 positionOffset = new Vector3(0, speed * pauseTime, 0);

        newArrowT.position = newArrowT.position + positionOffset + new Vector3(0, beat * speed, 0);
        Arrow newArrow = newArrowT.GetComponent<Arrow>();
        arrows.Enqueue(newArrow);
        newArrow.StartArrow(beat, pauseTime, speed, newArrowT.position, targetSpot.position - new Vector3(0, maxDistanceUnderTarget + .2f, 0));
    }

    public void PressedArrowKey()
    {
        if(arrows.Count > 0)
        {
            float distance = Vector2.Distance(arrows.Peek().transform.position, targetSpot.position);

            if(distance < 2)
            {
                if(distance < .15f) {plunderStatistics.ChangeStatistics(0, arrowDirection);}
                else if(distance < .4f) {plunderStatistics.ChangeStatistics(1, arrowDirection);}
                else if(distance < .8f) {plunderStatistics.ChangeStatistics(2, arrowDirection);}
                else if(distance < 1.3f) {plunderStatistics.ChangeStatistics(3, arrowDirection);}
                else {plunderStatistics.ChangeStatistics(4, arrowDirection);}

                RemoveArrow();
            }
        }
    }

    private void RemoveArrow()
    {
        Destroy(arrows.Peek().gameObject);
        arrows.Dequeue();
    }
}
