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
        if(perfectTimes.Count > 0)
        {
            float lifespan = 2 * (perfectTimes.Peek() - arrowStartTimes.Peek());
            float dTime = Clock.time - perfectTimes.Peek();

            if(dTime > lifespan/4) 
            {
                RemoveArrow();
                Debug.Log("miss");
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
            float timeToPerfect = (perfectTimes.Peek() - arrowStartTimes.Peek()) * 2;
            float lifeTime = Clock.time - arrowStartTimes.Peek();
            float dTime = Math.Abs(timeToPerfect - lifeTime);

            Debug.Log(dTime + " " + timeToPerfect);
            if(dTime < timeToPerfect/4)
            {
                if(dTime < timeToPerfect/40)
                {
                    Debug.Log("PERFECT +");
                    Debug.Log(timeToPerfect + " " + dTime);
                }
                else if(dTime < timeToPerfect/30)
                {
                    Debug.Log("PERFECT");
                }
                else if(dTime < timeToPerfect/12)
                {
                    Debug.Log("GREAT");
                }
                else if(dTime < timeToPerfect/6)
                {
                    Debug.Log("NICE");
                }
                else
                {
                    Debug.Log("MISS");
                }

                //RemoveArrow();
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
