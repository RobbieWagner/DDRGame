using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArrows : MonoBehaviour
{

    public static float timeToPerfect;
    [SerializeField] float timeUntilPerfect;

    [SerializeField] ArrowStream[] arrowStreams;

    [SerializeField] List<ArrowDeployment> levelArrows;
    [SerializeField] List<float> timesList;

    Queue<ArrowDeployment> arrows;
    Queue<float> times;

    Clock clock;

    private bool levelStarted;

    // Start is called before the first frame update
    void Start()
    {
        arrows = new Queue<ArrowDeployment>();
        times = new Queue<float>();

        timeToPerfect = timeUntilPerfect;

        levelStarted = false;
        clock = GameObject.Find("Clock").GetComponent<Clock>();

        StartCoroutine(Pause());

        for(int i = 0; i < levelArrows.Count; i++)
        {
            arrows.Enqueue(levelArrows[i]);
            times.Enqueue(timesList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(arrows.Count == 0) EndLevel();
        else if(Clock.time == times.Peek() - timeToPerfect)
        {
            ArrowDeployment arrowDeployment = arrows.Dequeue();
            times.Dequeue();
            arrowDeployment.Deploy(arrowStreams);
        } 
    }

    public void StartLevel()
    {
        levelStarted = true;
        clock.StartClock();
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2f);

        StartLevel();

        StopCoroutine(Pause());
    }

    void EndLevel()
    {
        Debug.Log("end of level");
    }
}
