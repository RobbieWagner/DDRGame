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

    public void AddArrow()
    {
        Transform newArrowT = Instantiate(arrow, transform).transform;
        Arrow newArrow = newArrowT.GetComponent<Arrow>();
        arrows.Enqueue(newArrow);
        float newTime = Clock.time;
        times.Enqueue(newTime);

        newArrowT.position = new Vector2(newArrowT.position.x, -3.5f + 10);
        newArrow.StartArrow();
        //Lerp new Arrow to point twice the distance they are from "perfect spot". This will let the arrow move offscreen, and make timing perfect placement easier.
    }

    public void PressedArrowKey()
    {
        //Called by MusicArrowKeyInput
        //Checks clock and time for valid input
        //if (clock.time is within certain time of queues first element) Add points
        //else if (clock.time is within another certain amounf of time) missed
        //Dequeue first time and arrow 
    }

}