using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float tempo;
    private float arrowSpeed;

    [SerializeField] private float delay = .35f;

    [SerializeField] ArrowStream[] arrowStreams;

    [SerializeField] List<ArrowDeployment> levelArrows;
    [SerializeField] List<float> beatValues;

    Queue<ArrowDeployment> arrows;
    Queue<float> times;

    Clock clock;

    private bool levelStarted;

    [SerializeField] float pauseTime;

    [SerializeField] AudioSource[] music;

    // Start is called before the first frame update
    void Start()
    {
        arrows = new Queue<ArrowDeployment>();
        times = new Queue<float>();

        arrowSpeed = tempo/60;

        levelStarted = false;
        clock = GameObject.Find("Clock").GetComponent<Clock>();

        StartCoroutine(Pause());
        AddStreamArrows();

        for(int i = 0; i < levelArrows.Count; i++)
        {
            arrows.Enqueue(levelArrows[i]);
            times.Enqueue(beatValues[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(levelStarted && !music[0].isPlaying) 
        {
            levelStarted = false;
            EndLevel();
        }
    }

    private void AddStreamArrows()
    {
        for(int i = 0; i < levelArrows.Count; i++)
        {
            ArrowDeployment arrowDeployment = levelArrows[i];

            for(int stream = 0; stream < arrowStreams.Length; stream++)
            {
                if(arrowDeployment.displayLeftUpDownRight[stream])
                {
                    arrowStreams[stream].AddArrow(beatValues[i], pauseTime, arrowSpeed);
                }
            }
        }
    }

    public void StartLevel()
    {
        levelStarted = true;
        clock.StartClock(times.Peek() - tempo);
        for(int i = 0; i < music.Length; i++) 
        music[i].Play();
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(pauseTime/arrowSpeed + delay);

        StartLevel();

        StopCoroutine(Pause());
    }

    void EndLevel()
    {
        Debug.Log("end of level");
    }
}
