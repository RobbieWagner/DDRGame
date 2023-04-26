using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStream : MonoBehaviour
{
    public GameObject arrow;
    private Queue<Arrow> arrows;
    private Queue<float> perfectTimes;
    private Queue<float> arrowStartTimes;

    [SerializeField] PlunderStatistics plunderStatistics;

    [SerializeField] Transform targetSpot;

    // Start is called before the first frame update
    void Start()
    {
        arrows = new Queue<Arrow>();
        perfectTimes = new Queue<float>();
        arrowStartTimes = new Queue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if(arrows.Count > 0 && arrows.Peek().transform.position.y < targetSpot.position.y)
        {
            float distance = Vector2.Distance(arrows.Peek().transform.position, targetSpot.position);
            if (distance >= 1.3f)
            {
                Debug.Log("MISS");
                RemoveArrow();
            }
        }
    }

    public void AddArrow(float arrowLifeSpan)
    {
        Transform newArrowT = Instantiate(arrow, transform).transform;
        Arrow newArrow = newArrowT.GetComponent<Arrow>();
        arrows.Enqueue(newArrow);

        float newTime = Clock.time + arrowLifeSpan;
        perfectTimes.Enqueue(newTime);
        arrowStartTimes.Enqueue(Clock.time);

        newArrowT.position = new Vector2(newArrowT.position.x, -3.5f + 10);
        newArrow.StartArrow(arrowLifeSpan * 2);
    }

    public void PressedArrowKey()
    {
        if(perfectTimes.Count > 0)
        {
            float distance = Vector2.Distance(arrows.Peek().transform.position, targetSpot.position);

            if(distance < 2)
            {
                if(distance < .15f)
                {
                    Debug.Log("PERFECT");
                    plunderStatistics.ChangeStatistics(0);
                }
                else if(distance < .4f)
                {
                    Debug.Log("EXCELLENT");
                    plunderStatistics.ChangeStatistics(1);
                }
                else if(distance < .8f)
                {
                    Debug.Log("GREAT");
                    plunderStatistics.ChangeStatistics(2);
                }
                else if(distance < 1.3f)
                {
                    Debug.Log("NICE");
                    plunderStatistics.ChangeStatistics(3);
                }
                else
                {
                    Debug.Log("MISS");
                    plunderStatistics.ChangeStatistics(4);
                }

                RemoveArrow();
            }
        }
        //Checks clock and time for valid input
        //if (clock.time is within certain time of queues first element) Add points
        //else if (clock.time is within another certain amounf of time) missed
        //Dequeue first time and arrow 
    }

    private void RemoveArrow()
    {
        Destroy(arrows.Peek().gameObject);
        arrows.Dequeue();
        perfectTimes.Dequeue();
        arrowStartTimes.Dequeue();
    }

}
