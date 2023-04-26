using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArrows : MonoBehaviour
{

    public static float timeToPerfect;
    [SerializeField] float timeUntilPerfect;

    Clock clock;

    private bool levelStarted;

    // Start is called before the first frame update
    void Start()
    {
        timeToPerfect = timeUntilPerfect;

        levelStarted = false;
        clock = GameObject.Find("Clock").GetComponent<Clock>();

        StartCoroutine(Pause());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
