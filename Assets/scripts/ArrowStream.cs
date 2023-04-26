using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStream : MonoBehaviour
{
    public GameObject arrow;
    private Queue<Arrow> arrows;
    private Queue<float> times;

    // Start is called before the first frame update
    void Start()
    {
        arrows = new Queue<Arrow>();
        times = new Queue<float>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddArrow(float arrowLifeSpan)
    {
        Transform newArrowT = Instantiate(arrow, transform).transform;
        Arrow newArrow = newArrowT.GetComponent<Arrow>();
        arrows.Enqueue(newArrow);
        float newTime = Clock.time + arrowLifeSpan;
        times.Enqueue(newTime);

        newArrowT.position = new Vector2(newArrowT.position.x, -3.5f + 10);
        newArrow.StartArrow(arrowLifeSpan * 2);
    }

    public void PressedArrowKey()
    {
        if(times.Count > 0)
        {
            float time = times.Peek();
            float dTime = Math.Abs(Clock.time - time);
            if(dTime < time/4)
            {
                Debug.Log("hi");
                if(dTime < time/40)
                {
                    Debug.Log("PERFECT +");
                }
                else if(dTime < time/30)
                {
                    Debug.Log("PERFECT");
                }
                else if(dTime < time/12)
                {
                    Debug.Log("GREAT");
                }
                else if(dTime < time/6)
                {
                    Debug.Log("NICE");
                }
                else
                {
                    Debug.Log("MISS");
                }

                Destroy(arrows.Peek().gameObject);
                arrows.Dequeue();
                times.Dequeue();
            }
        }
        //Checks clock and time for valid input
        //if (clock.time is within certain time of queues first element) Add points
        //else if (clock.time is within another certain amounf of time) missed
        //Dequeue first time and arrow 
    }

}
